using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CareerClimbers.Models;
using Microsoft.Ajax.Utilities;


namespace CareerClimbers.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        UserModel dbObj = new UserModel();
        ProfileModel dbProfile=new ProfileModel();
        StoryModel dbStory=new StoryModel();
        resourceModel dbResource = new resourceModel();
        interviewModel dbInterview=new interviewModel();
        questionTModel dbQ = new questionTModel();
        ratingModel dbRating = new ratingModel();
        adminModel dbAdmin= new adminModel();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddUser()
        {
            return View();
        }
        public ActionResult GetUpdateUser(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["ErrorMessage"] = "Invalid User ID!";
                return RedirectToAction("UserList");
            }

            var user = dbObj.User.FirstOrDefault(u => u.user_id == id);

            if (user == null)
            {
                TempData["ErrorMessage"] = "User not found!";
                return RedirectToAction("UserList");
            }

            var res = dbObj.User.FirstOrDefault(u => u.user_id == id);





            return View("GetUpdateUser",res);
        }

        [HttpPost]

        
        public ActionResult UpdateUser(User model, HttpPostedFileBase profile_picture)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the user by user_id
                var user = dbObj.User.FirstOrDefault(u => u.user_id == model.user_id);

                if (user == null)
                {
                    TempData["ErrorMessage"] = "User not found!";
                    return RedirectToAction("UserList");
                }

                // Update user details
                user.name = model.name;
                user.email = model.email;
                user.password = model.password;
                user.role = model.role;

                // Check if a new profile picture is uploaded
                if (profile_picture != null && profile_picture.ContentLength > 0)
                {
                    // Generate a unique file name
                    string fileName = Guid.NewGuid() + Path.GetExtension(profile_picture.FileName);

                    // Define the folder path to save the uploaded file
                    string folderPath = Server.MapPath("~/UploadedFiles/");

                    // Ensure the directory exists
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Save the uploaded file to the server
                    string filePath = Path.Combine(folderPath, fileName);
                    profile_picture.SaveAs(filePath);

                    // Update the profile picture in the database
                    user.profile_picture = "/UploadedFiles/" + fileName;
                }

                // Save the changes in the database
                dbObj.SaveChanges();

                TempData["SuccessMessage"] = "User details updated successfully!";
                return RedirectToAction("UserList");
            }

            TempData["ErrorMessage"] = "Invalid input. Please correct the errors.";
            return View(model); // Return to the update page if validation fails
        }










        [HttpPost]
        public ActionResult GetUser(User model, HttpPostedFileBase profile_picture)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Check if a file is uploaded
                    if (profile_picture != null && profile_picture.ContentLength > 0)
                    {
                        // Generate a unique file name
                        string fileName = Guid.NewGuid() + Path.GetExtension(profile_picture.FileName);

                        // Define the folder path
                        string folderPath = Server.MapPath("~/UploadedFiles/");

                        // Ensure the directory exists
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        // Save the file to the server
                        string filePath = Path.Combine(folderPath, fileName);
                        profile_picture.SaveAs(filePath);

                        // Store the relative path in the database
                        model.profile_picture = "/UploadedFiles/" + fileName;
                    }
                    else
                    {
                        // No file uploaded, handle this case as needed
                        model.profile_picture = null;
                    }

                    // Save user data in the database
                    User obj = new User
                    {
                        name = model.name,
                        email = model.email,
                        password = model.password,
                        role = model.role,
                        profile_picture = model.profile_picture,
                        created_at = DateTime.Now
                    };

                    dbObj.User.Add(obj);
                    dbObj.SaveChanges();

                    TempData["SuccessMessage"] = "User added successfully!";
                    return RedirectToAction("UserList");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error: {ex.Message}";
                    return View("AddUser", model);
                }
            }

            TempData["ErrorMessage"] = "Invalid input. Please correct the errors.";
            return View("AddUser", model);
        }



        public ActionResult UserList()
        {
            var res= dbObj.User.ToList();
            return View(res);
        }
        [HttpGet]
public ActionResult DeleteUser(int id)
{
    var res = dbObj.User.FirstOrDefault(x => x.user_id == id);
    if (res == null)
    {
        TempData["ErrorMessage"] = "User not found.";
        return RedirectToAction("UserList");
    }

    dbObj.User.Remove(res);
    dbObj.SaveChanges();

    return RedirectToAction("UserList");
}




        //#####################################################################################################
        public ActionResult AddProfile(int id)
        {
            var res = dbObj.User.FirstOrDefault(x => x.user_id == id);
            
            return View(res);
        }
        [HttpPost]
        public ActionResult GetProfile(Profile model)
        {
            Profile obj = new Profile();
            obj.user_fid = model.user_fid;
            obj.bio = model.bio;
            obj.skills = model.skills;
            obj.educational_background = model.educational_background;
            obj.career_goals = model.career_goals;
            obj.achievements = model.achievements;
            obj.social_links = model.social_links;

            dbProfile.Profiles.Add(obj);

            dbProfile.SaveChanges();

            return RedirectToAction("GetStory/"+ model.user_fid);
        }



        public ActionResult ViewProfile(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("Invalid ID provided.");
                }

                var profile = dbProfile.Profiles.FirstOrDefault(x => x.user_fid == id);
                if (profile == null)
                {
                    throw new KeyNotFoundException($"Profile with ID {id} not found.");
                }

                int profid = profile.profile_id; // Now safe to access
                var stories = dbStory.Story.Where(x => x.str_user_id == id).ToList();
                var resources = dbResource.resources.Where(x => x.rprofid == profid).ToList();
                var user = dbObj.User.FirstOrDefault(x => x.user_id == id);
                var question = dbQ.questionTs.Where(x => x.qprofid ==profid).ToList();
                var rating = dbRating.ratingTs.Where(x => x.ruserid == id).ToList();

                if (stories == null || !stories.Any())
                {
                    throw new Exception("No stories found for this profile.");
                }
                if (question == null)
                {
                    throw new Exception("No question found for this profile.");
                }
                if (rating == null)
                {
                    throw new Exception("No rating found for this profile.");
                }

                // Store data in ViewBag
                ViewBag.Profile = profile;
                ViewBag.Stories = stories;
                ViewBag.Resources = resources;
                ViewBag.User = user;
                ViewBag.Question = question;
                ViewBag.Rating = rating;

                return View();
            }
            catch (ArgumentException ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("Index", "Home");
            }
            catch (KeyNotFoundException ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("AddProfile", new { id });
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An unexpected error occurred: " + ex.Message;
                return RedirectToAction("GetStory", new { id });
            }
        }










        public ActionResult TempBtn()
        {
            return View();
        }
        
        public ActionResult GetStory(int id)
        {
            var res = dbObj.User.FirstOrDefault(x => x.user_id == id);
            return View(res);
        }
        [HttpPost]
        public ActionResult AddStory(Story model)
        {
            Story obj = new Story();
            obj.title = model.title;
            obj.str_user_id = model.str_user_id;
            obj.company = model.company;
            obj.description = model.description;
            obj.media_links = model.media_links;
            obj.published_at= DateTime.Now;
            obj.category = model.category;

            dbStory.Story.Add(obj);
            dbStory.SaveChanges();
            return RedirectToAction("UserList");
        }


        public ActionResult getresources(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["ErrorMessage"] = "Invalid Profile ID!";
                return RedirectToAction("UserList"); // Redirect to a safe page
            }

            var profile = dbProfile.Profiles.FirstOrDefault(x => x.profile_id == id);

            if (profile == null)
            {
                TempData["ErrorMessage"] = "Profile not found.";
                return RedirectToAction("UserList"); // Redirect to a relevant page
            }

            return View(profile); // Ensure the view expects a single Profile object
        }

        [HttpPost]
        public ActionResult putresources(resource data)
        {
            if (ModelState.IsValid)
            {
                resource r1 = new resource();
               
                r1.title = data.title;
                r1.type = data.type;
                r1.link = data.link;
                r1.description = data.description;
                r1.tags = data.tags;
                r1.created_at = data.created_at;  // Use the date from the form
                r1.rprofid = data.rprofid;
                
                dbResource.resources.Add(r1);  // Add the new resource instance (without resource_id)
                dbResource.SaveChanges();

                var Profile = dbProfile.Profiles.FirstOrDefault(x => x.profile_id==data.rprofid);
                return RedirectToAction("ViewProfile/"+Profile.user_fid);  // Redirect to the Index action or wherever appropriate
            }

            return View(data);  // Return the view with the submitted data if the model is invalid
        }

        //public ActionResult readresources()
        //{
        //    //var res = rm1.resource.FirstOrDefault();


        //    //return View(res);
        //}

        public ActionResult viewResource(int id, int userid)
        {
            var resource = dbResource.resources.FirstOrDefault(x => x.rid == id);
            var user = dbObj.User.FirstOrDefault(x => x.user_id == userid);

            if (resource == null || user == null)
            {
                return HttpNotFound(); // Handle missing data
            }

            ViewBag.Resource = resource;
            ViewBag.User = user;

            return View();
        }


        public ActionResult seeResource(int id)
        {
            // Get the resource by ID
            var resource = dbResource.resources.FirstOrDefault(x => x.rid == id);

            // Check if the resource is null
            if (resource == null)
            {
                return HttpNotFound("Resource not found.");
            }

            // Get the profile associated with the resource's rprofid
            int profid = resource.rprofid;
            var profile = dbProfile.Profiles.FirstOrDefault(x => x.profile_id == profid);

            // Check if the profile is null
            if (profile == null)
            {
                return HttpNotFound("Profile not found.");
            }

            // Get the user associated with the profile's user_fid
            int userid = profile.user_fid;
            var user = dbObj.User.FirstOrDefault(x => x.user_id == userid);

            // Check if the user is null
            if (user == null)
            {
                return HttpNotFound("User not found.");
            }

            // Assign values to ViewBag for use in the view
            ViewBag.User = user;
            ViewBag.Resource = resource;

            return View();
        }




        public ActionResult addInterviewQuestion(int? id)
        {
            // Fetch the profile by the id (assuming the id is the profile_id or user_id)
            var profile = dbProfile.Profiles.FirstOrDefault(p => p.profile_id == id);
            if (profile == null)
            {
                TempData["ErrorMessage"] = "Profile not found.";
                return RedirectToAction("UserList");
            }

            return View(profile); // Ensure you're passing the Profile model here
        }


        [HttpPost]

        public ActionResult putInterviewQuestion(interview data)
        {
            try
            {
                // Create a new interview object
                interview obj = new interview
                {
                    question = data.question,
                    category = data.category,
                    difficulty = data.difficulty,
                    solution = data.solution,
                    iprofid = data.iprofid
                };

                // Add the object to the database context and save changes
                dbInterview.interviews.Add(obj);
                dbInterview.SaveChanges();

                return RedirectToAction("/"); // Redirect after successful save
            }
            catch (DbUpdateException ex)
            {
                // Log the error and the inner exception for more details
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    Console.WriteLine(ex.InnerException.InnerException?.Message); // Log further inner exception if available
                }

                // You can also log this error to a file or a logging service if needed

                // Return an error message to the user
                TempData["ErrorMessage"] = "An error occurred while saving the interview question. Please try again.";
                return View(data); // Return the user to the form with the error message
            }
            catch (Exception ex)
            {
                // Catch all other general exceptions
                Console.WriteLine(ex.Message);
                TempData["ErrorMessage"] = "An unexpected error occurred. Please try again.";
                return View(data); // Return the user to the form with the error message
            }
        }




        public ActionResult addQuestion(int? id)
        {
            // Fetch the profile by the id (assuming the id is the profile_id or user_id)
            var profile = dbProfile.Profiles.FirstOrDefault(p => p.profile_id == id);
            if (profile == null)
            {
                TempData["ErrorMessage"] = "Profile not found.";
                return RedirectToAction("UserList");
            }

            return View(profile); // Ensure you're passing the Profile model here
        }

        [HttpPost]
        public ActionResult putQuestion(questionT data)
        {
            
               

                // Log received data

                questionT obj = new questionT
                {
                    qprofid = data.qprofid,
                    question = data.question,
                    category = data.category,
                    solution = data.solution,
                    difficulty = data.difficulty
                };

                dbQ.questionTs.Add(obj);
                dbQ.SaveChanges();

            var Profile = dbProfile.Profiles.FirstOrDefault(x => x.profile_id == data.qprofid);

            if (Profile == null)
            {
                return HttpNotFound("Resource not found.");
            }
            int userid = Profile.user_fid;
                return RedirectToAction("ViewProfile/"+userid);
            }
            
        
        public ActionResult seeAnswer(int id)
        {
            var res = dbQ.questionTs.FirstOrDefault(x=>x.qid==id);
            return View(res);
        }
        [HttpPost]
        public ActionResult getRating(ratingT data)
        {
            try
            {
                ratingT obj = new ratingT
                {
                    ruserid = data.ruserid,
                    rating = data.rating,
                    comments = data.comments
                };

                dbRating.ratingTs.Add(obj);
                dbRating.SaveChanges();

                return RedirectToAction("ViewProfile", new { id = data.ruserid });
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
                return View("Error"); // Redirect to an error page or display a message
            }
        }



        public ActionResult ViewAdmin()
        {
            // Fetch data from the database
            var resources = dbResource.resources.ToList();
            var users = dbObj.User.ToList();
            var rating = dbRating.ratingTs.ToList();
            var profile = dbProfile.Profiles.ToList();

            // Store data in ViewBag
            ViewBag.Profile = profile;
            ViewBag.Resources = resources;
            ViewBag.Rating = rating;
            ViewBag.User = users;

            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(string adminName, string adminEmail, string adminPhone)
        {
            // Handle the logic to add the new admin here
            // Example:
            var newAdmin = new admin
            {
                aname = adminName,
                email = adminEmail,
                phoneno = adminPhone // Consider encrypting the password before storing it
            };
             dbAdmin.admins.Add(newAdmin);
            dbAdmin.SaveChanges();
            

            // Optionally return a success message or redirect
            return RedirectToAction("viewAdmin"); // Or wherever you want to redirect
        }











    }
}