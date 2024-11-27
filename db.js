const fs = require('fs');
const path = require('path');

// Define paths
const namespace = 'Site.Blocks';
const blocksDir = path.join(__dirname, ...namespace.split('.'));
const outputFilePath = path.join(__dirname, 'wwwroot', 'assets', 'db.json');

// Helper function to recursively find files with specific extensions
function findFiles(dir, extension, fileList = []) {
    const files = fs.readdirSync(dir);

    for (const file of files) {
        const filePath = path.join(dir, file);
        const stat = fs.statSync(filePath);

        if (stat.isDirectory()) {
            // Recursively search subdirectories
            findFiles(filePath, extension, fileList);
        } else if (file.endsWith(extension)) {
            // Add matching file to the list
            fileList.push(filePath);
        }
    }

    return fileList;
}

// Create a .settings.json file if it doesn't exist
function createSettingsFileIfMissing(razorFilePath) {
    const settingsFilePath = razorFilePath.replace(/\.razor$/, '.settings.json');

    if (!fs.existsSync(settingsFilePath)) {
        const fileName = path.basename(razorFilePath, '.razor');
        const settingsContent = JSON.stringify({ Title: fileName }, null, 2);

        fs.writeFileSync(settingsFilePath, settingsContent, 'utf-8');
        console.log(`Created settings file: ${settingsFilePath}`);
    }
}

// Merge the content of all .settings.json files
function mergeSettingsFiles(filePaths) {
    const mergedData = [];

    for (const filePath of filePaths) {
        try {
            const fileData = JSON.parse(fs.readFileSync(filePath, 'utf-8'));

            // Add Namespace key based on the file path
            const component = filePath
                .replace(blocksDir + path.sep, '')
                .replace(/\\/g, '.')
                .replace(/\//g, '.')
                .replace(/\.settings\.json$/, '');

            // Add Namespace key based on the file path
            fileData['Namespace'] = component;

            mergedData.push(fileData);
        } catch (error) {
            console.error(`Error reading or parsing ${filePath}:`, error.message);
        }
    }

    return mergedData;
}

// Ensure the output directory exists
function ensureOutputDirectory(outputPath) {
    const dir = path.dirname(outputPath);
    if (!fs.existsSync(dir)) {
        fs.mkdirSync(dir, { recursive: true });
    }
}

// Main script
try {
    console.log('Searching for .razor files...');
    const razorFiles = findFiles(blocksDir, '.razor');

    console.log(`Found ${razorFiles.length} .razor files. Checking for missing .settings.json files...`);
    for (const razorFile of razorFiles) {
        createSettingsFileIfMissing(razorFile);
    }

    console.log('Searching for .settings.json files...');
    const settingsFiles = findFiles(blocksDir, '.settings.json');

    if (settingsFiles.length === 0) {
        console.log('No .settings.json files found.');
        return;
    }

    console.log(`Found ${settingsFiles.length} .settings.json files.`);

    console.log('Merging files...');
    const mergedData = mergeSettingsFiles(settingsFiles);

    console.log('Ensuring output directory exists...');
    ensureOutputDirectory(outputFilePath);

    console.log('Writing merged data to db.json...');
    fs.writeFileSync(outputFilePath, JSON.stringify(mergedData, null, 2), 'utf-8');

    console.log('Merged data successfully written to db.json');
} catch (error) {
    console.error('An error occurred:', error.message);
}
