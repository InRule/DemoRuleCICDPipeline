using InRule.Repository.Service.Data.Requests;
using InRule.Repository.Service.Requests;
using System;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Configuration;
using System.Xml;

namespace CheckinRequestListener
{
    public class RuleApplicationParameterInspector : IParameterInspector
    {
        public object BeforeCall(string operationName, object[] inputs)
        {
            /*
            if (string.Equals(operationName, "CheckinRuleApp", StringComparison.OrdinalIgnoreCase))
            {
                RepositoryWebRequest request = (RepositoryWebRequest)inputs.FirstOrDefault();
                var checkinRequest = request as CheckinRuleAppRequest;
                //Add your logic here to work with checkinRequest if desired
            }
            */
            return null;
        }
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            try
            {
                if (string.Equals(operationName, "CheckinRuleApp", StringComparison.OrdinalIgnoreCase))
                {
                    //This bit of less-than-pretty logic gets the name and new Revision of the Rule App that was just checked in if you need that
                    var ruleAppXml = ((InRule.Repository.Service.Data.Responses.CheckinRuleAppResponse)returnValue).RuleAppXml.Xml;
                    XmlDocument d = new XmlDocument();
                    d.LoadXml(ruleAppXml);
                    XmlNode defTag = d.GetElementsByTagName("RuleApplicationDef")[0];
                    string ruleAppName = defTag.Attributes["Name"].Value;
                    string ruleAppRevision = defTag.Attributes["Revision"].Value;

                    string ruleAppsToInclude = ConfigurationManager.AppSettings["AutoPromoteRuleAppsNamed"];
                    if (ruleAppsToInclude.Contains(ruleAppName))
                    {
                        string org = ConfigurationManager.AppSettings["AzureDevOpsPipelineOrg"];
                        string project = ConfigurationManager.AppSettings["AzureDevOpsPipelineProject"];
                        string pipelineId = ConfigurationManager.AppSettings["AzureDevOpsPipelineID"];
                        string authToken = ConfigurationManager.AppSettings["AzureDevOpsAuthToken"];
                        AzureDevOpsApiHelper.QueuePipelineBuild(org, project, pipelineId, authToken);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in RuleApplicationParameterInspector following checkin: " + ex.Message);
            }
        }
    }
}