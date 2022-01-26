# Blaze's Blog #

A Blog ASP.Net Core (MVC) App. This blog is meant for those who are planning to go into or have already gone into the tech field.
So those who went through a bootcamp, are self taught, just went through an apprenticeship that landed them a position, and more! There are lots of ways to get into tech.
Those with traditional backgrounds are welcome as well! For this project I will be using SQLite instead of SQL Server to hold the databases, one for users and one blogs.

# Requirements: #
## Project Components: ##
* -[x] MVC 
* -[x] Identity Framework 
* -[x] Entity Framework using SQLite
* -[x] Models: Post
    *  -[x] Id (numeric id of the post)
    * -[x] Title (title or subject the post)
    * -[x] Content (the main body of the post)
    * -[x] TimeStamp (when the post was created)
## Features: ##
* -[x] Any user (not logged in) can view a list of posts.
* -[x] Authenticated user (logged in) can create, update, and delete posts.

## Stretch Goals ##
* -[x] Authenticated users can only edit their own posts and not those of other users.

## Extra Goals ##
* -[ ] Change CSS to not have default styles of .Net
* -[ ] Make a logo for the site
* -[ ] Make a background for the site
* -[ ] Deployment

## Some Images ##

### Home Page (Anon View) ###
*Anon user can see homepage and can also access posts but they can not create, edit, or delete anything until they have registered*

![HomePage](https://user-images.githubusercontent.com/77519894/148849600-9c31a9b8-0e48-41a2-bd27-95cc972ee37a.png)

### Posts Page (anon view) ###
*Anon user does not have ability to edit or delete any of the posts they can only click on the link leading to the blog to read the entire blog. They also can not create
new posts*

![AnonViewsPosts](https://user-images.githubusercontent.com/77519894/148849692-24729320-cf43-4ca5-9852-ee37a327279a.png)

### Posts Page (Authenticated User View) ###
*Authenticated user has the ability to edit or delete their own post, they can also create new posts*

![Userviewpost](https://user-images.githubusercontent.com/77519894/148849745-f5c937d7-2adb-4f92-9b59-17e4d640fa49.png)

### View of Blog Post (Authenticated User View) ###
*Authenticated user has ability to click on edit as long as they are looking at their own post, if they are not looking at their own then they can not see or complete the edit
functionionality*

![Usersviewdetails](https://user-images.githubusercontent.com/77519894/148849783-e568fe3b-0244-4d23-a1b9-d4d07e558704.png)
