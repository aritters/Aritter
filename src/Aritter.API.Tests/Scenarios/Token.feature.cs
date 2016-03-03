﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.0.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Aritter.API.Tests.Scenarios
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class TokenFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Token.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Token", "\tTo ensure system security\r\n    I want to check if the system is authenticating a" +
                    "nd generating tokens", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Token")))
            {
                Aritter.API.Tests.Scenarios.TokenFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 5
#line 6
    testRunner.Given("I have cleaned the database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "FirstName",
                        "Email",
                        "MustChangePassword",
                        "IsActive"});
            table1.AddRow(new string[] {
                        "admin",
                        "Administrator",
                        "admin@aritter.com",
                        "0",
                        "1"});
#line 7
    testRunner.And("I created the users", ((string)(null)), table1, "And ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Generate token with valid username and password")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Token")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ClearScenarioContext")]
        public virtual void GenerateTokenWithValidUsernameAndPassword()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generate token with valid username and password", new string[] {
                        "ClearScenarioContext"});
#line 12
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 13
    testRunner.Given("I created a \'POST\' request with content \'grant_type=password&username=admin&passw" +
                    "ord=jki@b46t\' like text", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.When("I send to the \'token\' resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
 testRunner.Then("The result should be a \'OK\' status code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "JSONPath"});
            table2.AddRow(new string[] {
                        "access_token"});
            table2.AddRow(new string[] {
                        "token_type"});
            table2.AddRow(new string[] {
                        "expires_in"});
            table2.AddRow(new string[] {
                        "refresh_token"});
#line 16
    testRunner.And("The result should contain", ((string)(null)), table2, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Generate token with invalid username and password")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Token")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ClearScenarioContext")]
        public virtual void GenerateTokenWithInvalidUsernameAndPassword()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generate token with invalid username and password", new string[] {
                        "ClearScenarioContext"});
#line 24
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 25
    testRunner.Given("I created a \'POST\' request with content \'grant_type=password&username=test&passwo" +
                    "rd=test\' like text", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 26
 testRunner.When("I send to the \'token\' resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
 testRunner.Then("The result should be a \'BadRequest\' status code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "JSONPath",
                        "Value"});
            table3.AddRow(new string[] {
                        "error",
                        "invalid_grant"});
            table3.AddRow(new string[] {
                        "error_description",
                        "The user name or password is incorrect."});
#line 28
    testRunner.And("The result should contain values", ((string)(null)), table3, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Refresh token sucessfully")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Token")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ClearScenarioContext")]
        public virtual void RefreshTokenSucessfully()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Refresh token sucessfully", new string[] {
                        "ClearScenarioContext"});
#line 34
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 35
    testRunner.Given("I created a \'POST\' request with content \'grant_type=password&username=admin&passw" +
                    "ord=jki@b46t\' like text", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 36
 testRunner.When("I send to the \'token\' resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.Then("The result should be a \'OK\' status code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "JSONPath"});
            table4.AddRow(new string[] {
                        "access_token"});
            table4.AddRow(new string[] {
                        "token_type"});
            table4.AddRow(new string[] {
                        "expires_in"});
            table4.AddRow(new string[] {
                        "refresh_token"});
#line 38
    testRunner.And("The result should contain", ((string)(null)), table4, "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "JSONPath",
                        "Key"});
            table5.AddRow(new string[] {
                        "refresh_token",
                        "RefreshTokenKey"});
#line 44
    testRunner.And("will store the JSON value", ((string)(null)), table5, "And ");
#line 47
    testRunner.Given("I created a \'POST\' request with content \'grant_type=refresh_token&refresh_token={" +
                    "RefreshTokenKey}\' like text", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 48
 testRunner.When("I send to the \'token\' resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
 testRunner.Then("The result should be a \'OK\' status code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "JSONPath"});
            table6.AddRow(new string[] {
                        "access_token"});
            table6.AddRow(new string[] {
                        "token_type"});
            table6.AddRow(new string[] {
                        "expires_in"});
            table6.AddRow(new string[] {
                        "refresh_token"});
#line 50
    testRunner.And("The result should contain", ((string)(null)), table6, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Refresh token already used")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Token")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ClearScenarioContext")]
        public virtual void RefreshTokenAlreadyUsed()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Refresh token already used", new string[] {
                        "ClearScenarioContext"});
#line 58
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 59
    testRunner.Given("I created a \'POST\' request with content \'grant_type=password&username=admin&passw" +
                    "ord=jki@b46t\' like text", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 60
 testRunner.When("I send to the \'token\' resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
 testRunner.Then("The result should be a \'OK\' status code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "JSONPath"});
            table7.AddRow(new string[] {
                        "access_token"});
            table7.AddRow(new string[] {
                        "token_type"});
            table7.AddRow(new string[] {
                        "expires_in"});
            table7.AddRow(new string[] {
                        "refresh_token"});
#line 62
    testRunner.And("The result should contain", ((string)(null)), table7, "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "JSONPath",
                        "Key"});
            table8.AddRow(new string[] {
                        "refresh_token",
                        "RefreshTokenKey"});
#line 68
    testRunner.And("will store the JSON value", ((string)(null)), table8, "And ");
#line 71
    testRunner.Given("I created a \'POST\' request with content \'grant_type=refresh_token&refresh_token={" +
                    "RefreshTokenKey}\' like text", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 72
 testRunner.When("I send to the \'token\' resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 73
 testRunner.Then("The result should be a \'OK\' status code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "JSONPath"});
            table9.AddRow(new string[] {
                        "access_token"});
            table9.AddRow(new string[] {
                        "token_type"});
            table9.AddRow(new string[] {
                        "expires_in"});
            table9.AddRow(new string[] {
                        "refresh_token"});
#line 74
    testRunner.And("The result should contain", ((string)(null)), table9, "And ");
#line 80
    testRunner.Given("I created a \'POST\' request with content \'grant_type=refresh_token&refresh_token={" +
                    "RefreshTokenKey}\' like text", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 81
 testRunner.When("I send to the \'token\' resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 82
 testRunner.Then("The result should be a \'BadRequest\' status code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "JSONPath",
                        "Value"});
            table10.AddRow(new string[] {
                        "error",
                        "invalid_grant"});
#line 83
    testRunner.And("The result should contain values", ((string)(null)), table10, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Refresh token invalid")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Token")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ClearScenarioContext")]
        public virtual void RefreshTokenInvalid()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Refresh token invalid", new string[] {
                        "ClearScenarioContext"});
#line 88
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 89
    testRunner.Given("I created a \'POST\' request with content \'grant_type=refresh_token&refresh_token=i" +
                    "nvalidRefreshToken\' like text", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 90
 testRunner.When("I send to the \'token\' resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 91
 testRunner.Then("The result should be a \'BadRequest\' status code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "JSONPath",
                        "Value"});
            table11.AddRow(new string[] {
                        "error",
                        "invalid_grant"});
#line 92
    testRunner.And("The result should contain values", ((string)(null)), table11, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
