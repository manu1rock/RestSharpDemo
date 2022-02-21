using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo
{
    public static class Reporter
    {
        private static ExtentReports extentReport;
        private static ExtentHtmlReporter htmlReporter;
        private static ExtentTest extentTest;

        public static void SetUpReport(dynamic path, string documentTitle, string reportName)
        {
            htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Config.DocumentTitle = documentTitle;
            htmlReporter.Config.ReportName = reportName;

            extentReport = new ExtentReports();
            extentReport.AttachReporter(htmlReporter);
        }

        public  static void LogToReport(Status status, string message)
        {
            extentTest.Log(status, message);
        }

        public static void CreateTest(string testName)
        {
            extentTest = extentReport.CreateTest(testName);
        }

        public static void FlushReport()
        {
            extentReport.Flush();
        }

        public static void TestStatus(string status)
        {
            if (status.Equals("Pass"))
            {
                extentTest.Pass("Test case passed");
            }
            else
            {
                extentTest.Fail("Test case failed");
            }
        }
    }
}
