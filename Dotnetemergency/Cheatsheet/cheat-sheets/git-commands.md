# GIT cheat sheet
## Create repositories
- ```> git init``` *Turns an existing directory into a git repository*
- ```> git clone <url>``` *Clones a repository that already exists on your local machine*

## Branches
  - ```> git branch <branch-name>``` *Creates a new branch*
  - ```> git checkout <branch-name>``` *Switches to the specified branch and updates  the working directory* 
  - ```> git checkout -b <branch-name>``` *Creates a new branch and switch to the branch*
  - ```> git branch -d <branch-name>``` *Deletes the specified branch*
  - ```> git merge <branch-name>``` *Merges the specified branch into the current branch (Fastforward merge)*
  - ```> git merge --no-ff <branch-name>``` *Merges the specified branch into the current branch (No fastforward merge)*

## Make changes
_**Staging area:** is the preview for your next commit. When you commit, git wil use the changes form the staging area._ **Always do a git add, before a git commit!**

- ```> git add <filename>``` *Adds the file to the staging area*
- ```> git add .``` *Adds all files to the staging area*
- ```> git commit -m "<message>"``` *Commits the files for the staging area*

## Synchronize changes
- ```> git push``` *Uploads all local branch commits to the remote repository*
- ```> git push origin <branch-name>``` *Uploads the specified branch to the corresponding remote branch, if not exits on the remote, it will be created*
- ```> git pull``` *Updates your current local working branch with all new commits from the corresponding remote branch.*
- ```> git pull origin <branch-name>``` *Will pull changes from the origin remote specified branch and merge them to the local checked-out branch.*

## Information
- ```> git log --graph --online --decorate --all``` *Lists version history for the current branch*
- ```> git status``` *Displays the state of the working directory and the staging area.*


## Remotes
_**Remotes:**  are links to the remote repositories that are versions of your project that are hosted on the Internet or network somewhere._

_**remote-url**: is the same url used to clone repositories._

- ```> git remote -v```*show the remotes of the current local repository
- ```> git remote add <remote-alias> <remote-url>``` *adds a remote*
- ```> git remote remove <remote-alias>```*removes a remote*
- ```> git remote rename <old-remote-alias> <new-remote-alias>```*renames a remote*

## How to's
### How to start from an existing remote repository:
- ```> git clone <url>```
- ```> git checkout -b <branch-name>```
- ```> git status ```

###  How to create a new repository from existing code
- ```> git init```
- ```> git remote add origin <remote-url> . ```
- ```> git add . ```
- ```> git commit -m "<commit message>"```
- ```> git push origin master```

### How to make a commit and push it to the remote repository:
- ```> git status ```
- ```> git add . ``` 
- ```> git commit -m "<message>" ```
- ```> git status ```

_**Be sure everything is commited  before moving on**_

- ```> git pull origin <branch-name>```
- ```> git push origin <branch-name>```
- ```> git status ```

### How to change the 'origin' remote
- ```> git remote -v```
- ```> git remote remove origin```
- ```> git remote add origin <new-remote-url>```
