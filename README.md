## Demo Rule CI/CD Pipeline
This repo demonstrates two different CI/CD flows handling Rule Applications.

### File-Based IrJS : Test and Build upon GitHub Checkin
This pipeline is a demonstration of file-based Rule Apps that use GitHub as the repository for both Rule Apps and Test Scenarios, allowing them to be tested and compiled using the irDistribution service upon checkin.

1. A Rule App being checked into GitHub triggers the pipeline to execute.
2. The Rule App is pulled from GitHub and run against all Test Scenarios that exist in the same folder.
3. If all test scenarios pass, the Rule App is compiled via the irDistribution Service into a .js file.
4. The compiled js file is published as a build artifact.

##### Requirements
- The appropriate InRuleLicense.xml file is saved in the Library Secure File store
- The appropriate irDistributionKey variable has been set in an IrJsCredentials Library Variable Group store

### Catalog-Based : Test and Promote upon irCatalog Checkin
This pipeline is a demonstration of irCatalog-based Rule Apps that use GitHub as the repository for Test Scenarios, allowing them to be tested and promoted from one catalog to another when the Rule App is checked into a Catalog.

1. A custom component is added to the irCatalog deployment that allows Rule App checkins to trigger code.
2. A Rule App being checked into the irCatalog runs code that manually triggers the pipeline to execute.
3. The Rule App is pulled from the Catalog and run against all Test Scenarios that exist in the same folder.
4. If all test scenarios pass, the Rule App is promoted from a source irCatalog instance to a target irCatalog instance - IE from Development to UAT

##### Requirements
- The appropriate InRuleLicense.xml file is saved in the Library Secure File store
- The appropriate source credential variables have been set in a SourceCatCredsForDev  Library Variable Group store
	- SourceCatalogUri
	- SourceCatalogUsername
	- SourceCatalogPassword (secret)
- The appropriate destination credential variables have been set in a DestCatCredsForUAT  Library Variable Group store
	- DestinationCatalogUri
	- DestinationCatalogUsername
	- DestinationCatalogPassword (secret)