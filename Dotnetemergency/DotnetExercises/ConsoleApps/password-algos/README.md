# Lab Password

This lab will teach you how to create a console app with your own business logic using an existing repository. In your code you will learn to work with a dictionary, Interfaces and classes.

For this exercise you will **not** create the exercise from scratch. Instead you will update this given repository.

## Exercise

Implement an additional algorithm in the password app with the name, shift. The result of the algorithm is an encrypted password that is as strong as possible. The result contains only lowercase letters.
Except for (\*):

- a must be 4
- b must be 8
- e must be 3
- i must be !
- o must be 0

For the exception you need to use a Dictionary.

You don't have to be able to decrypt the password again.

for example:

```bash
> donnet run -- test123 shift
> generated password: ykcmnny

> dotnet run -- azertyuiopqsdfghjklmwxcvbn1234567890 shift
> generated password: ff0kcgmxptqj!xm3cgtrllg!sfsuzj44ljw4
```

### When done:

Upload the created library to gitlab in your student-name folder.

# Hints and Tricks

- Look at the examples
- Use a dictionary for the exceptions(\*)
- Use the C# cheat sheet on gitlab.
- Use the dotnet cli cheat sheet on gitlab.
- Use the git cheat sheet on gitlab.
