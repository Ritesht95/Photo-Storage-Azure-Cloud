# Photo-Storage-Azure-Cloud

## How to Use
	- There are 3 webpages [1. Default(Home), 2. AddPhoto and 3. SearchPhoto]
	1. You have 2 options on home page to add and search photo.
	2. On AddPhoto Page, You need to enter Photo title, Description, Keywords(for searching) and Image file.
	3. On submission of that form metadata of Photo will be added to SQL Database of Azure and Image file will get stored in BLOB Storage(Warm) of Azure.
	4. On SearchPhoto Page, You just need to enter the keyword to search and you will get list of photos with metadata which were added before.

## Nuget Packages Used:
	- WindowsAzure.Storage(v9.3.2)
	- UnofficialAzure.StorageClient(v1.0.0)

  
