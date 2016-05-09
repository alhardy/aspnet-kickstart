using System.Collections.Generic;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace AspNet.KickStart.VsixWizards
{
    public class ChildWizard : IWizard
    {
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
        }

        public void RunFinished()
        {
        }

        // Add global replacement parameters     
        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind,
            object[] customParams)
        {
            // Add custom parameters.         
            replacementsDictionary.Add("$saferootprojectname$", RootWizard.GlobalDictionary["$saferootprojectname$"]);
        }


        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}