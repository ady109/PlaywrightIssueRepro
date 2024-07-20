# Playwright Issue Repro

I have a console application that uses Playwright version `1.44`.

I have upgraded to Playwright version `1.45` and the application has stopped working.

With Playwright version `1.44` it works successfully. E.G. I can login to the 3rd party website using my real username and password, submit the login form, I am then redirected to the next step in the login process to enter 3 random letters from my memorable security phrase.

With Playwright version `1.45` is doesn't work. E.G. I can enter my real username and password into the login form and submit those details as before with Playwright version `1.44` but with Playwright version `1.45` I am not redirected to the next step in the process as I am using Playwright version `1.44`, instead I get an error message on the screen:
![image](https://github.com/user-attachments/assets/1db0e1b5-7a85-48a7-a127-279e5766f51f)

This code is a mimimal repro of the issue using a fake username and password, so when successully submitting the login form (which only happens with Playwright version `1.44`), instead of being redirected to the next page in the login process, it will instead show validation errors in red on the login page, to show the username/password are invalid.

Has there been a breaking change between Playwright version `1.44` and `1.45`?

Is there additional configuration I need to add to the Playwright setup for it now to work in Playwright version `1.45`?
