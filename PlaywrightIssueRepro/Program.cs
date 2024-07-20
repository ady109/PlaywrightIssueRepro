using Microsoft.Playwright;

namespace PlaywrightIssueRepro;

internal class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Installing browsers...");

        // The following line installs the default browsers. If you only need a subset of browsers,
        // you can specify the list of browsers you want to install among: chromium, chrome,
        // chrome-beta, msedge, msedge-beta, msedge-dev, firefox, and webkit.
        // var exitCode = Microsoft.Playwright.Program.Main(new[] { "install", "webkit", "chrome" });
        // If you need to install dependencies, you can add "--with-deps"
        var exitCode = Microsoft.Playwright.Program.Main(["install", "firefox"]);
        if (exitCode != 0)
        {
            Console.WriteLine("Failed to install browsers");
            Environment.Exit(exitCode);
        }

        Console.WriteLine("Browsers installed");

        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            Timeout = 10_000
        });

        await using var context = await browser.NewContextAsync(new BrowserNewContextOptions
        {
            ScreenSize = new ScreenSize { Width = 1920, Height = 1080 },
            ViewportSize = new ViewportSize { Width = 1910, Height = 950 },
            IgnoreHTTPSErrors = true
        });

        // Open new page (pseudo maximized)
        var page = await context.NewPageAsync();
        await page.GotoAsync("https://online.lloydsbank.co.uk/personal/logon/login.jsp?WT.ac=TopLink/Navigation/Personal/");

        const string userIdSelector = "input[name=\"frmLogin\\:strCustomerLogin_userID\"]";
        await page.ClickAsync(userIdSelector);
        await page.FillAsync(userIdSelector, "username");

        const string passwordSelector = "input[name=\"frmLogin\\:strCustomerLogin_pwd\"]";
        await page.ClickAsync(passwordSelector);
        await page.FillAsync(passwordSelector, "password");

        try
        {
            var navigationTask = page.WaitForURLAsync("https://online.lloydsbank.co.uk/personal/logon/login.jsp?messageKey=IB:9210358&mobile=false");
            await page.ClickAsync("input[alt=\"Continue\"]");
            await navigationTask;

            Console.WriteLine("Succeeded");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            await page.CloseAsync();
        }

        Console.ReadKey();
    }
}
