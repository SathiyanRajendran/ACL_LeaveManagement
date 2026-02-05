# Moving Project to GitHub

I have already initialized the local Git repository and committed all your code (including the `.gitignore` file).

Follow these steps to push it to your GitHub account:

### Step 1: Create Remote Repository
1.  Log in to [GitHub](https://github.com).
2.  Click the **+** icon in the top-right and select **New repository**.
3.  **Repository name**: `ACL_LeaveManagement` (or your preferred name).
4.  **Important**: uncheck "Add a README file", "Add .gitignore", and "Choose a license". The repository **must be empty**.
5.  Click **Create repository**.

### Step 2: Push Code
Copy the HTTPS or SSH URL of your new repository (e.g., `https://github.com/YourUsername/ACL_LeaveManagement.git`).

Run the following commands in your terminal:

```powershell
# Link your local repo to the remote one (replace <YOUR_REPO_URL> with the actual URL)
git remote add origin <YOUR_REPO_URL>

# Rename the branch to 'main' (modern standard) if it isn't already
git branch -M main

# Push your code
git push -u origin main
```

### Verification
Refresh your GitHub repository page. You should see all your project files there!
