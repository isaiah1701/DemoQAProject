using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using System;
using OpenQA.Selenium.Support.UI;
using Xunit;    
namespace DemoQAProject;

public class DemoQAProject
{





  private static  IWebDriver driver = null;
   
    private static WebDriverWait wait;

    public DemoQAProject()
    {


        if(driver == null)
        {
            string browser = "chrome"; // Change this to "firefox" or "edge" if needed
            switch (browser.ToLower())
            {

                case "chrome":
                    driver = new ChromeDriver();
                    break;

                case "edge":
                    driver = new EdgeDriver();
                    break;
                default:
                    throw new ArgumentException("Invalid browser specified");
            }
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

    }

    [Fact]
    public void TestTextBox()
    {

        IWebElement element = driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div[2]/div/div[1]"));
        element.Click();
        IWebElement textBox = driver.FindElement(By.XPath("//span[text()='Text Box']"));
        textBox.Click();
        IWebElement fullName = driver.FindElement(By.Id("userName"));
        fullName.SendKeys("John Doe");
        IWebElement email = driver.FindElement(By.Id("userEmail"));
        email.SendKeys("isaiah.michael@cognizant.com");
        IWebElement currentAddress = driver.FindElement(By.Id("currentAddress"));
        currentAddress.SendKeys("2800 S. River Road, Des Plaines, IL 60018");
        IWebElement permanentAddress = driver.FindElement(By.Id("permanentAddress"));
        permanentAddress.SendKeys("2800 S. River Road, Des Plaines, IL 60018");

        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("window.scrollBy(0,500)");


        IWebElement submit = driver.FindElement(By.Id("submit"));
        submit.Click();

         

        var output = driver.FindElement(By.Id("output"));

        Assert.Contains("John Doe", output.Text);
        Assert.Contains("isaiah.michael@cognizant.com", output.Text);



        js.ExecuteScript("window.scrollBy(0,-1000)");

        ClickHomeScreen();


    }

    public void ClickHomeScreen()
    {
        IWebElement homescreen = driver.FindElement(By.XPath("//*[@id=\"app\"]/header/a/img"));
        homescreen.Click();
    }



    [Fact]
    public void TestCheckBox()
    {
        IWebElement element = driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div[2]/div/div[1]"));
        element.Click();
        IWebElement checkBox = driver.FindElement(By.XPath("//*[@id=\"item-1\"]/span"));
        checkBox.Click();
        IWebElement expand = driver.FindElement(By.XPath("//*[@id=\"tree-node\"]/div/button[1]"));
        expand.Click();

        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("window.scrollBy(0,500)");

        IWebElement home = driver.FindElement(By.XPath("//*[@id=\"tree-node\"]/ol/li/span/label/span[3]"));
        home.Click();
        js.ExecuteScript("window.scrollBy(0,700)");


        var result = driver.FindElement(By.Id("result"));

        Assert.Equal("You have selected :\r\nhome\r\ndesktop\r\nnotes\r\ncommands\r\ndocuments\r\nworkspace\r\nreact\r\nangular\r\nveu\r\noffice\r\npublic\r\nprivate\r\nclassified\r\ngeneral\r\ndownloads\r\nwordFile\r\nexcelFile", result.Text);


        ClickHomeScreen();


    }

    [Fact]
    public void testRadioButton()
    {




        IWebElement element = driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div[2]/div/div[1]"));
        element.Click();
        IWebElement radioBox = driver.FindElement(By.XPath("//*[@id=\"item-2\"]"));
        radioBox.Click();
        IWebElement yesRadio = driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div/div[2]/div[2]/div[2]/label"));
        yesRadio.Click();


        var result = driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div/div[2]/div[2]/p/span"));

        Assert.Equal("Yes", result.Text);


        ClickHomeScreen();

    }


    [Fact]
    public void testWebTableEntry()
    {
        driver.Navigate().GoToUrl("https://demoqa.com/webtables");
        IWebElement add = driver.FindElement(By.XPath("//*[@id=\"addNewRecordButton\"]"));
        add.Click();
        IWebElement firstName = driver.FindElement(By.XPath("//*[@id=\"firstName\"]"));
        firstName.SendKeys("John");
        IWebElement lastName = driver.FindElement(By.XPath("//*[@id=\"lastName\"]"));
        lastName.SendKeys("Doe");
        IWebElement email = driver.FindElement(By.XPath("//*[@id=\"userEmail\"]"));
        email.SendKeys("abc@abc.com");
        IWebElement age = driver.FindElement(By.XPath("//*[@id=\"age\"]"));
        age.SendKeys("25");
        IWebElement salary = driver.FindElement(By.XPath("//*[@id=\"salary\"]"));
        salary.SendKeys("10000");
        IWebElement department = driver.FindElement(By.XPath("//*[@id=\"department\"]"));
        department.SendKeys("IT");
        IWebElement submit = driver.FindElement(By.XPath("//*[@id=\"submit\"]"));
        submit.Click();

        wait.Until(driver => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[2]/div[2]/div[3]")));

  
        IWebElement searchBox = driver.FindElement(By.XPath("//*[@id=\"searchBox\"]"));
        searchBox.SendKeys("John");


        var table = driver.FindElement(By.CssSelector("#app > div > div > div > div.col-12.mt-4.col-md-6 > div.web-tables-wrapper > div.ReactTable.-striped.-highlight > div.rt-table > div.rt-tbody > div:nth-child(1) > div > div:nth-child(1)"));

        Assert.Contains("John", table.Text);
        
         

        ClickHomeScreen();


    }


    [Fact]
    public void testWebTableSearch()
    {
     
        IWebElement element = driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div[2]/div/div[1]"));
        element.Click();
        IWebElement webTables = driver.FindElement(By.XPath("//*[@id=\"item-3\"]"));
        webTables.Click();
        IWebElement searchBox = driver.FindElement(By.XPath("//*[@id=\"searchBox\"]"));
        searchBox.SendKeys("Kierra");
        var table = driver.FindElement(By.CssSelector("#app > div > div > div > div.col-12.mt-4.col-md-6 > div.web-tables-wrapper > div.ReactTable.-striped.-highlight > div.rt-table > div.rt-tbody > div:nth-child(1) > div > div:nth-child(1)"));
        Assert.Contains("Kierra", table.Text);
       
        ClickHomeScreen();
    }


    [Fact]
    public void testButtonClick() {

        driver.Navigate().GoToUrl("https://demoqa.com/buttons");
        IWebElement rightButtonClick = driver.FindElement(By.Id("rightClickBtn"));
       
        Actions actions = new Actions(driver);
        actions.ContextClick(rightButtonClick).Perform();


        IWebElement doubleClick = driver.FindElement(By.XPath("//*[@id=\"doubleClickBtn\"]"));
        actions.DoubleClick(doubleClick).Perform();

        IWebElement singleClick = driver.FindElement(By.XPath("//button[text()='Click Me']"));
        singleClick.Click();


        var rightClickTest = driver.FindElement(By.Id("rightClickMessage"));
        var doubleClickTest = driver.FindElement(By.Id("doubleClickMessage"));
        var singleClickTest = driver.FindElement(By.Id("dynamicClickMessage"));

        Assert.Equal("You have done a right click", rightClickTest.Text);
        Assert.Equal("You have done a double click", doubleClickTest.Text); 
        Assert.Equal("You have done a dynamic click", singleClickTest.Text);


        ClickHomeScreen();


     }


   
}