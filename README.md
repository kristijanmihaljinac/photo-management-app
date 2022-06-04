# PHOTO MANAGEMENT APP - PROJECT ASIGNMENT

Used technologies:
 - Frontend: TypeScript, Angular 14, TailwindCSS
 - Backend: C#, .NET 6 Web API, Clean code architecture, DDD,
 - Database: Sql Server
    

Create an app to upload and browse photos.

Functional requirements:

- The application supports work with a registered, anonymous and administrator type of
    user
- User registration must be enabled using Google, Github and local account
    - when registering user, you have to choose one of the packages for use: FREE, PRO or
       GOLD - limit the price of the package yourself (e.g. upload size, daily upload limit,
       maximum spend of uploaded photos, etc.)
    - user can track the current consumption in his current package
    - user can change the packet once a day (change is valid from the following day)
- user can set one or more hashtags and a description of photo when uploading
    - the user can choose how the image will be processed before being saved (e.g. resize,
       png / jpeg / bmp format)
- user can browse all uploaded photos
    - registered user can modify the description and hash tags of their photos while the
       anonymous user can only browse uploaded photos
    - by default, thumbnails of 10 last uploaded photos are displayed with a description,
       author, upload datetime and hashtags
    - click on the photo thumbnail displays the whole photo
- user can search photos based on given filter
    - hashtags, size, upload datetime range, author
- user can download the photo
    - When downloading, the user can choose to download the original photo or the
       photo with applied selected filters (e.g., resize + sepia + blur + format)
- administrator can do everything what registered user can, and additionally
    - modify the profile and packages of user
    - view user actions and user statistics
    - manage images of any user

Nonfunctional requirements:

- logging of every action has to be implemented: by who, when and what operation was
    made
- depending on the chosen configuration, photos have to be saved on local storage or
    Amazon s3 bucket
- App has to be implemented as web or desktop application using object oriented
    language
