const fs = require('fs');
const path = require('path');

const blocksDir = path.join(__dirname, 'Site', 'Blocks');
const wwwRootAssets = path.join(__dirname, 'wwwroot', 'assets', 'images', 'blocks');
const dbFile = path.join(__dirname, 'wwwroot', 'assets', 'db.json');

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

				if (path.basename(itemPath) === 'Dark.jpg') {
					const darkTarget = path.join(blockAssetsDir, 'Dark.jpg');
					fs.copyFileSync(itemPath, darkTarget);
				}

				if (path.basename(itemPath) === 'Light.jpg') {
					const lightTarget = path.join(blockAssetsDir, 'Light.jpg');
					fs.copyFileSync(itemPath, lightTarget);
				}
			}
		}
	});
};

// Start processing from the root blocks directory
processFolder(blocksDir);

// Write merged Settings.json to db.json
fs.writeFileSync(dbFile, JSON.stringify(mergedSettings, null, 2));

console.log('Processing complete.');
