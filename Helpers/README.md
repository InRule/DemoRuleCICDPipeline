## Helper Applications
These helper applications are used at various points in the pipeline.  3 of the tools are sourced from the [CommandLineTools Developer Samples](https://github.com/InRule/Samples/tree/master/Developer%20Samples/CommandLineTools), and the fourth one has the code local to this repo.

#### BuildIrJsRuleApp
This application allows InRule's irDistribution service to be called from a command line to compile an irJS Rule Application into the javascript package.

#### ExecuteTests
This sample allows a file-based Test Suite to be run against a file-based Rule Application from a command line. Please note that this project requires irSDK to be installed locally, as not all referenced assemblies are available from NuGet.

#### PromoteRuleApp
This sample allows a Rule Application to be promoted from one Catalog instance to another from a command line. It supports the Rule App being sourced either from a Catalog or the filesystem, and outputs the compiled JS to a file on the file system.

#### CheckinRequestListener IrCatalogExtension
This application allows InRule's irDistribution service to be called from a command line to compile an irJS Rule Application into the javascript package.