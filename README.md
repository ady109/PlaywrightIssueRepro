# Playwright Issue Repro

I have a console application that uses Playwright version `1.44`.

I have upgraded to Playwright version `1.45` and the application has stopped working.

Using Playwright version `1.44` it works successfully. E.G. I can login to the 3rd party website using my real username and password, submit the login form, I am then redirected to the next step in the login process to enter 3 random letters from my memorable security phrase.

Using Playwright version `1.45` it doesn't work. E.G. I can enter my real username and password into the login form and submit those details as before however I am not redirected to the next step in the login process; instead I get an error message on the screen:
![image](https://github.com/user-attachments/assets/1db0e1b5-7a85-48a7-a127-279e5766f51f)

The code in this repo is a mimimal repro of the issue using a fake username and password.

Because I'm using a fake username and password in this minimal repro an expected outcome looks slightly different.  

*Expected Outcome:*
After the form is submitted you should get a red validation warning message on screen to say the details entered in the login form are invalid.

*Actual Outcome:*
An error message is displayed on the screen:
![image](https://github.com/user-attachments/assets/1db0e1b5-7a85-48a7-a127-279e5766f51f)

Has there been any breaking changes between Playwright version `1.44` and `1.45`?

Is there additional configuration I need to add to get Playwright verson `1.45` to behave the same as Playwright version `1.44`?

Is there a way to compare the requests being sent to the 3rd party website between the versions?
