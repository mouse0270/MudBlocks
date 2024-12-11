const fs = require('fs');
const path = require('path');
const sharp = require('sharp');

const blocksDir = path.join(__dirname, 'Site', 'Blocks');
const wwwRootAssets = path.join(__dirname, 'wwwroot', 'assets', 'images', 'blocks');
const dbFile = path.join(__dirname, 'Site', 'Services', 'StaticData.cs');

// Ensure target directory exists
const ensureDirExists = (dir) => {
	if (!fs.existsSync(dir)) {
		fs.mkdirSync(dir, { recursive: true });
	}
};

ensureDirExists(wwwRootAssets);

const mergedSettings = [];

// Recursively process block folders
// Recursively process block folders
const processFolder = (folderPath, blockCategory = null) => {
	fs.readdirSync(folderPath).forEach((item) => {
		const itemPath = path.join(folderPath, item);

		if (fs.lstatSync(itemPath).isDirectory()) {
			// If we are in the first-level subfolder, consider it a blockCategory
			const isBlockCategory = path.dirname(itemPath) === blocksDir;
			const currentCategory = isBlockCategory ? item : blockCategory;
			processFolder(itemPath, currentCategory);
		} else {
			if (blockCategory) {
				const blockName = path.basename(path.dirname(itemPath));
				const blockAssetsDir = path.join(wwwRootAssets, blockCategory, blockName);
				ensureDirExists(blockAssetsDir);

				const settingsFile = path.join(path.dirname(itemPath), 'Settings.json');
				if (!fs.existsSync(settingsFile)) {
					// Create Settings.json if it doesn't exist
					const settingsContent = { Title: blockName };
					console.log('Creating Settings.json for', blockName);
					fs.writeFileSync(settingsFile, JSON.stringify(settingsContent, null, 2));
				}

				// Now process the (possibly newly created) Settings.json
				const existingIndex = mergedSettings.findIndex((setting) => setting.Namespace === `${blockCategory}.${blockName}`);

				if (existingIndex === -1) {
					const settingsContent = JSON.parse(fs.readFileSync(settingsFile, 'utf-8'));
					console.log('Processing', `${blockCategory}.${blockName}`);
					mergedSettings.push({
						...settingsContent,
						Category: blockCategory,
						Namespace: `${blockCategory}.${blockName}`,
					});
				}

				if (path.basename(itemPath) === 'Dark.jpg' || path.basename(itemPath) === 'Dark.jpeg' || path.basename(itemPath) === 'Dark.png') {
					const darkTarget = path.join(blockAssetsDir, path.basename(itemPath));
					//fs.copyFileSync(itemPath, darkTarget);
					sharp(itemPath).webp({ quality: 80 }).toFile(darkTarget.replace(path.extname(itemPath), '.webp'));
				}

				if (path.basename(itemPath) === 'Light.jpg' || path.basename(itemPath) === 'Light.jpeg' || path.basename(itemPath) === 'Light.png') {
					const lightTarget = path.join(blockAssetsDir, path.basename(itemPath));
					//fs.copyFileSync(itemPath, lightTarget);
					sharp(itemPath).webp({ quality: 80 }).toFile(lightTarget.replace(path.extname(itemPath), '.webp'));
				}
			}
		}
	});
};
// Function to convert JSON to C# static class
function generateStaticClass(data) {
	return `
  using System;
  using System.Collections.Generic;
  
  namespace MudBlocks.Site.Services
  {
	  public static class StaticData
	  {
		  public static List<Database.Block> Blocks { get; } = InitializeBlocks();
		  private static List<Database.Block> InitializeBlocks()
		  {
			try
			{
				return new List<Database.Block> {
				  ${data.map((item) => `
					new Database.Block
					{
						Namespace = "${item.Namespace}",
						AltUrls = new List<string> { ${(item?.AltUrls ?? []).map((k) => `"${k}"`).join(", ")} },
						Title = "${item.Title}",
						Description = @"${item.Description}",
						Keywords = new List<string> { ${(item?.Keywords ?? []).map((k) => `"${k}"`).join(", ")} },
						Authors = new List<BlockService.Author>
						{
							${(item?.Authors ?? []).map(
								(author) => `
							new BlockService.Author
							{
								Name = "${author.Name}",
								Url = "${author.Url}",
								Image = "${author.Image}",
								Socials = new Dictionary<string, string>
								{
									${Object.entries(author.Socials)
										.map(
										([key, value]) => `{"${key}", "${value}"}`
										)
										.join(", ")}
								}
							}`
							).join(",")}
						},
						${item?.Created ? `Created = DateOnly.Parse("${item.Created}"),` : ``}
						${item?.Updated ? `Updated = DateOnly.Parse("${item.Updated}"),` : ``}
						Tags = new List<string>()
					}`
				  ).join(",")}
		  		};
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
				return new List<Database.Block>();
			}
		 }
	  }
  }`;
}

// Start processing from the root blocks directory
processFolder(blocksDir);

// Get StaticData.cs content
const StaticDB = generateStaticClass(mergedSettings);

// Write merged Settings.json to db.json
fs.writeFileSync(dbFile, StaticDB, 'utf-8');

console.log('Processing complete.');
