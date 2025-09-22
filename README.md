# Job Portal API – ASP.NET Core 6 Backend

---

## 📌 Overview  
The **Job Portal API** is a backend system built with **ASP.NET Core 6 Web API**, designed to streamline job opportunities for students, graduates, and companies.  
It supports **authentication, job posting, job applications, freelancer projects, company offers, user ratings, file uploads, email notifications, and Zoom integration for interviews**.  

The project follows **Clean Architecture**, **Repository + Specification Patterns**, and leverages **EF Core** and **JWT Authentication**.  

---

## 🚀 Features  
- 🔐 **Authentication & Accounts**  
  - User & Company registration and login  
  - JWT authentication with roles  
  - Password reset with email verification  
  - Update user/company profile & upload CVs  

- 💼 **Job Management**  
  - Post, edit, delete jobs (companies)  
  - Apply to jobs with CV & message (users)  
  - Track applicants for each job  
  - Get jobs a user applied to  

- 🧑‍💻 **Freelance Projects**  
  - Companies can post freelance jobs  
  - Users can browse gigs and apply  
  - Companies can send offers to freelancers  

- 🏢 **Company Management**  
  - Company profile with bio, country, city  
  - Post jobs and manage applicants  
  - Send offers directly to users  

- 📂 **File Uploads**  
  - Upload CVs, profile pictures, and documents  

- ⭐ **Ratings & Reviews**  
  - Users can be rated and reviewed after collaboration  
  - Retrieve ratings with comments  

- 📹 **Zoom Integration**  
  - Schedule interviews via Zoom API  
  - Generate meeting links and tokens  

- ✉️ **Email Notifications**  
  - Forgot password & verification emails  
  - Configurable SMTP (Gmail supported)  

---

## 🛠️ Tech Stack  
- **.NET 6 Web API**  
- **Entity Framework Core 6**  
- **ASP.NET Identity + JWT Authentication**  
- **AutoMapper**  
- **Swagger / Swashbuckle**  
- **SQL Server**  
- **Zoom API Integration**  
- **SMTP Email (Gmail)**  

---

## 📦 Key APIs  

### 🔑 Accounts  
- `POST /api/account/register`  
- `POST /api/account/login`  
- `POST /api/account/forgetpassword`  
- `PUT /api/account/resetpassword`  
- `PUT /api/account/updateprofile`  

### 💼 Jobs  
- `GET /api/job`  
- `POST /api/job`  
- `PUT /api/job/{id}`  
- `DELETE /api/job/{id}`  
- `POST /api/applyjob`  

### 🧑‍💻 Freelancers  
- `GET /api/frelancer`  
- `POST /api/frelancer`  

### 🏢 Companies  
- `GET /api/company/{id}`  
- `PUT /api/company/update`  

### ⭐ Ratings  
- `POST /api/user/rate`  
- `GET /api/user/ratings/{id}`  

### 📹 Zoom  
- `POST /api/zoom/createmeeting`  
- `GET /api/zoom/getuserdetails`  

---

## 🌟 Future Enhancements  
- Add **Job Recommendations (AI-based)**  
- Advanced filtering & search with ElasticSearch  
- Payment integration for premium job postings  
- Docker & Kubernetes deployment  
- Mobile app frontend (Flutter/React Native)  

---

## 🤝 Contributing  
Contributions are welcome!  
Please fork and submit a pull request.  
