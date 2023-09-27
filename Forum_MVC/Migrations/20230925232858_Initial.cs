using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum_MVC.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AmountOfTopics = table.Column<int>(type: "int", nullable: false),
                    VisibilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    DislikeCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostStatistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PostStatisticsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_PostStatistics_PostStatisticsId",
                        column: x => x.PostStatisticsId,
                        principalTable: "PostStatistics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    DislikeCount = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    PostStatisticsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_PostStatistics_PostStatisticsId",
                        column: x => x.PostStatisticsId,
                        principalTable: "PostStatistics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostStatisticsId = table.Column<int>(type: "int", nullable: true),
                    TopicOfPostId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_PostStatistics_PostStatisticsId",
                        column: x => x.PostStatisticsId,
                        principalTable: "PostStatistics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TopicsOfPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VisibilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicsOfPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopicsOfPosts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicsOfPosts_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TopicsOfPosts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "AmountOfTopics", "Name", "VisibilityStatus" },
                values: new object[,]
                {
                    { 1, 5, "General Discussions", "Active" },
                    { 2, 3, "Coding Challenges and Solutions", "Active" },
                    { 3, 4, "Web Development", "Active" },
                    { 4, 9, "Mobile App Development", "Suspended" },
                    { 5, 21, "Game Development", "Suspended" },
                    { 6, 7, "Software Engineering", "Active" },
                    { 7, 2, "Programming Languages", "Active" },
                    { 8, 8, "Database Management", "Active" },
                    { 9, 19, "Algorithms and Data Structures", "Active" },
                    { 10, 6, "DevOps and Continuous Integration", "Suspended" },
                    { 11, 3, "Front-end Development", "Active" },
                    { 12, 4, "Back-end Development", "Active" },
                    { 13, 1, "Machine Learning and AI", "Suspended" },
                    { 14, 14, "Cybersecurity", "Active" },
                    { 15, 9, "Code Reviews and Feedback", "Suspended" }
                });

            migrationBuilder.InsertData(
                table: "PostStatistics",
                columns: new[] { "Id", "DislikeCount", "LikeCount" },
                values: new object[,]
                {
                    { 1, 3, 10 },
                    { 2, 2, 8 },
                    { 3, 1, 12 },
                    { 4, 0, 15 },
                    { 5, 2, 11 },
                    { 6, 1, 9 },
                    { 7, 0, 14 },
                    { 8, 3, 13 },
                    { 9, 2, 10 },
                    { 10, 1, 8 },
                    { 11, 0, 7 },
                    { 12, 2, 6 },
                    { 13, 1, 9 },
                    { 14, 0, 11 },
                    { 15, 2, 14 },
                    { 16, 1, 12 },
                    { 17, 2, 10 },
                    { 18, 0, 8 },
                    { 19, 1, 7 },
                    { 20, 2, 9 },
                    { 21, 3, 15 },
                    { 22, 1, 13 },
                    { 23, 0, 11 },
                    { 24, 2, 10 },
                    { 25, 1, 8 },
                    { 26, 0, 7 },
                    { 27, 2, 6 }
                });

            migrationBuilder.InsertData(
                table: "PostStatistics",
                columns: new[] { "Id", "DislikeCount", "LikeCount" },
                values: new object[,]
                {
                    { 28, 1, 5 },
                    { 29, 0, 4 },
                    { 30, 2, 3 },
                    { 31, 1, 2 },
                    { 32, 3, 10 },
                    { 33, 2, 8 },
                    { 34, 1, 12 },
                    { 35, 0, 15 },
                    { 36, 2, 11 },
                    { 37, 1, 9 },
                    { 38, 0, 14 },
                    { 39, 3, 13 },
                    { 40, 2, 10 },
                    { 41, 1, 8 },
                    { 42, 0, 7 },
                    { 43, 2, 6 },
                    { 44, 1, 9 },
                    { 45, 0, 11 },
                    { 46, 2, 14 },
                    { 47, 1, 12 },
                    { 48, 2, 10 },
                    { 49, 2, 9 },
                    { 50, 3, 15 },
                    { 51, 1, 13 },
                    { 52, 0, 11 },
                    { 53, 2, 10 },
                    { 54, 1, 8 },
                    { 55, 0, 7 },
                    { 56, 2, 6 },
                    { 57, 1, 5 },
                    { 58, 0, 4 },
                    { 59, 2, 3 },
                    { 60, 1, 2 },
                    { 61, 3, 10 },
                    { 62, 2, 8 },
                    { 63, 1, 12 },
                    { 64, 0, 15 },
                    { 65, 2, 11 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "ImageUrl", "Password", "PostStatisticsId", "Username" },
                values: new object[,]
                {
                    { 3, "mikejohnson@example.com", "~/img/people/2.jpg", "Pa$$w0rd#2023", null, "MikeJohnson" },
                    { 9, "robertlee@example.com", "~/img/people/5.jpg", "H@ppyC0der", null, "RobertLee" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "PostStatisticsId", "Text", "Title", "TopicOfPostId", "UserId" },
                values: new object[,]
                {
                    { 1, 9, null, 1, "Are you interested in diving into the exciting world of machine learning, but don't know where to start? You're in luck! In this comprehensive post, we'll explore some fundamental machine learning algorithms that are perfect for those who are new to the field. We'll break down complex concepts into easy-to-understand explanations, providing you with a solid foundation to build upon. From linear regression to decision trees and neural networks, you'll gain insights into various algorithms that power the world of artificial intelligence. So, whether you're a student looking to expand your knowledge or a professional considering a career change, this post has something for everyone. Get ready to embark on your machine learning journey!", "Machine Learning Algorithms for Beginners", null, 3 },
                    { 7, 8, null, 7, "Data visualization is a powerful way to make sense of complex datasets and communicate insights effectively. With a plethora of data visualization tools available today, choosing the right one can be challenging. Fear not! In this extensive and meticulously crafted post, we'll provide you with a comprehensive comparison of popular data visualization tools. We'll explore the strengths and weaknesses of tools like Tableau, Power BI, D3.js, and many more. You'll also find detailed information on pricing, data integration capabilities, and user-friendliness. Whether you're a data analyst, a business intelligence professional, or a data science enthusiast, this post will help you make an informed decision and elevate your data visualization game. Get ready to create stunning and informative visualizations that drive better decision-making.", "Data Visualization Tools Comparison", null, 9 },
                    { 27, 1, null, 27, "Renewable energy sources like solar and wind power are crucial for a sustainable future, but they are intermittent by nature. Energy storage technologies play a pivotal role in harnessing renewable energy effectively. In this meticulously researched post, we'll explore the recent advances in energy storage and their impact on the transition to renewable energy. Whether you're an environmental advocate, an energy professional, or simply interested in the future of clean energy, you'll find this post enlightening. We'll delve into the various energy storage solutions, from lithium-ion batteries and pumped hydro storage to cutting-edge technologies like flow batteries and thermal energy storage. You'll discover how energy storage can stabilize the grid, store excess energy for later use, and enable the integration of renewable sources into the energy mix. We'll also discuss the economic and environmental benefits of energy storage and its role in reducing greenhouse gas emissions. Join us on this journey to explore the exciting advancements in renewable energy storage and their potential to reshape our energy landscape.", "Advances in Renewable Energy Storage", null, 3 },
                    { 34, 11, null, 34, "Using Vue.js for state management in front-end applications. Explore Vuex, the official state management library for Vue.js, and learn how to build maintainable and efficient Vue.js applications. This post covers the fundamentals of Vue.js state management and provides practical examples to help you get started.", "Vue.js and State Management", null, 3 },
                    { 38, 12, null, 38, "Integrating databases like MongoDB and MySQL with Node.js applications. Learn how to perform database operations in Node.js, from connecting to databases and executing queries to implementing data models and handling migrations. This post covers various database integration scenarios and best practices.", "Database Integration with Node.js", null, 3 },
                    { 42, 13, null, 42, "Using deep learning for computer vision and image processing tasks. Dive into the world of computer vision and explore how deep learning can be used to analyze and manipulate images and videos. This post covers topics like image classification, object detection, and image generation.", "Computer Vision and Image Processing", null, 3 },
                    { 46, 14, null, 46, "Handling security incidents and conducting cyber forensics investigations. Learn how to respond to security incidents, investigate breaches, and collect digital evidence for forensic analysis. This post covers incident response best practices and forensic tools.", "Incident Response and Cyber Forensics", null, 3 },
                    { 50, 2, null, 50, "Comparing various sorting algorithms and their time complexity. Dive deep into the world of sorting algorithms, including bubble sort, merge sort, quicksort, and more. This post provides a comprehensive comparison of these algorithms, helping you choose the right one for your needs.", "Sorting Algorithms Comparison", null, 3 },
                    { 54, 6, null, 54, "Best practices for software testing and ensuring software quality. Discover the importance of testing in the software development life cycle and learn how to write effective test cases, perform regression testing, and ensure the quality of your software products.", "Testing and Quality Assurance", null, 3 },
                    { 58, 7, null, 58, "Using Python for data science and machine learning projects. Learn how to use Python libraries like NumPy, Pandas, and Scikit-learn to analyze data, build machine learning models, and extract insights from your data.", "Python Programming for Data Science", null, 3 },
                    { 62, 8, null, 62, "Optimizing SQL queries for improved database performance. This post covers SQL query optimization strategies, indexing techniques, and tools for diagnosing and improving database performance.", "SQL Query Optimization Techniques", null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "ImageUrl", "Password", "PostStatisticsId", "Username" },
                values: new object[,]
                {
                    { 1, "johndoe@example.com", "~/img/people/1.png", "StrongP@ssw0rd", 30, "JohnDoe" },
                    { 2, "janesmith@example.com", "~/img/people/people/1w.jpg", "Secure1234!", 20, "JaneSmith" },
                    { 4, "sarahbrown@example.com", "~/img/people/2w.jpg", "C0dingRocks!", 28, "SarahBrown" },
                    { 5, "davidclark@example.com", "~/img/people/3.jpg", "TechGeek#123", 26, "DavidClark" },
                    { 6, "emilywilson@example.com", "~/img/people/3w.jpg", "Pr0gramm3r@", 2, "EmilyWilson" },
                    { 7, "alexgarcia@example.com", "~/img/people/4.jpg", "D3v3l0pment$", 13, "AlexGarcia" },
                    { 8, "lisadavis@example.com", "~/img/people/4w.jpg", "DataSecurity#1", 15, "LisaDavis" },
                    { 10, "karenanderson@example.com", "~/img/people/5w.jpg", "Innov8tive&", 8, "KarenAnderson" },
                    { 11, "marktaylor@example.com", "~/img/people/6.jpg", "MasterM1nd!", 27, "MarkTaylor" },
                    { 12, "oliviawhite@example.com", "~/img/people/6w.jpg", "P@ssionateD3v", 14, "OliviaWhite" },
                    { 13, "brianmiller@example.com", "~/img/people/7.jpg", "Creat1v3C0de", 11, "BrianMiller" },
                    { 14, "sophiajohnson@example.com", "~/img/people/7w.jpg", "2FA4Security", 6, "SophiaJohnson" },
                    { 15, "williamwilson@example.com", "~/img/people/8.jpg", "G3n!usC0d3r", 12, "WilliamWilson" },
                    { 16, "jessicamoore@example.com", "~/img/people/8w.jpg", "DebugGuru#7", 17, "JessicaMoore" },
                    { 17, "danielbrown@example.com", "~/img/people/9.jpg", "WebM@ster$2023", 18, "DanielBrown" },
                    { 18, "emmamartinez@example.com", "~/img/people/9w.jpg", "0penS0urce", 23, "EmmaMartinez" },
                    { 19, "michaelsmith@example.com", "~/img/people/10.jpg", "C0mput3rWh1z", 31, "MichaelSmith" },
                    { 20, "avaharris@example.com", "~/img/people/10w.jpg", "H@rdw@r3L0v3r", 7, "AvaHarris" },
                    { 21, "jamesjohnson@example.com", "~/img/people/11.jpg", "Alph@Num3ric", 9, "JamesJohnson" },
                    { 22, "miataylor@example.com", "~/img/people/11w.jpg", "Art1f1c1@lInt3ll1g3nc3", 21, "MiaTaylor" },
                    { 23, "ethanwilliams@example.com", "~/img/people/12.jpg", "B1gData&R3search", 1, "EthanWilliams" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "DislikeCount", "ImageUrl", "LikeCount", "PostId", "PostStatisticsId", "Text", "UserId" },
                values: new object[] { 13, 1, null, 12, 27, null, "Quantum cryptography is fascinating. It's the future of security.", 8 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "PostStatisticsId", "Text", "Title", "TopicOfPostId", "UserId" },
                values: new object[,]
                {
                    { 2, 11, null, 2, "When it comes to building a web application, one of the most crucial decisions you'll face is selecting the right backend framework. The choice you make can significantly impact your project's success, scalability, and maintenance. In this extensively detailed post, we'll provide you with a wealth of information and tips to help you make an informed decision. We'll dive deep into the world of backend development, discussing the pros and cons of various frameworks, such as Node.js, Django, Ruby on Rails, and more. We'll also explore real-world use cases and provide valuable insights from experienced developers. By the end of this post, you'll be equipped with the knowledge needed to confidently choose the perfect backend framework for your web application, setting you up for success in your development journey.", "Choosing the Right Backend Framework", null, 4 },
                    { 3, 6, null, 3, "Virtual reality (VR) is changing the way we interact with digital content and experiences. Whether you're a game developer, a UX designer, or simply curious about the world of VR, this in-depth post is a must-read. We'll guide you through the process of designing and creating immersive VR experiences that captivate users and provide a true sense of presence. From the hardware and software requirements to best practices in 3D modeling and user interface design, we'll cover it all. You'll also learn about the latest VR technologies, including headsets, motion controllers, and haptic feedback devices. Get ready to embark on a journey into the world of virtual reality and discover how you can create unforgettable VR experiences.", "Creating Immersive Virtual Reality Experiences", null, 5 },
                    { 4, 7, null, 4, "Natural Language Processing (NLP) is a fascinating field at the intersection of linguistics and computer science. In this extensive post, we'll take you on a deep dive into the world of NLP using the powerful Python programming language. Whether you're interested in sentiment analysis, chatbots, or language translation, NLP has applications in various domains, and Python is the go-to language for NLP enthusiasts. We'll start with the basics, covering tokenization, stemming, and part-of-speech tagging, and gradually progress to advanced topics like word embeddings and deep learning models. You'll also get hands-on experience with popular NLP libraries such as NLTK, spaCy, and Transformers. By the end of this post, you'll have the knowledge and tools to embark on your NLP projects and contribute to this exciting field.", "Natural Language Processing with Python", null, 6 },
                    { 5, 3, null, 5, "Running a high-traffic website comes with its unique set of challenges. If you're a web developer or an IT professional responsible for managing web infrastructure, this comprehensive post is a goldmine of knowledge. We'll explore a wide range of strategies and architectures to ensure your website can handle large volumes of traffic without compromising on performance or reliability. From load balancing and caching techniques to content delivery networks (CDNs) and database optimization, we'll cover all the essential aspects of website scalability. You'll also learn about real-world case studies from popular websites that have successfully scaled to millions of users. By the end of this post, you'll be well-equipped to tackle the challenges of high-traffic websites and keep your users happy.", "Scalability Strategies for High-Traffic Websites", null, 7 },
                    { 6, 14, null, 6, "The Internet of Things (IoT) is transforming the way we interact with everyday objects, from smart thermostats to connected cars. However, this interconnectedness also brings security challenges that need to be addressed, especially in the context of 5G connectivity. In this extensively researched post, we'll delve deep into the world of IoT security. We'll explore the unique threats and vulnerabilities associated with IoT devices and networks and provide you with a comprehensive toolkit of security best practices and solutions. From device authentication and encryption to secure firmware updates and intrusion detection systems, you'll learn how to safeguard your IoT ecosystem. Additionally, we'll discuss the latest developments in 5G technology and how they impact IoT security. Whether you're a cybersecurity professional or an IoT enthusiast, this post will equip you with the knowledge and tools to ensure the security of your connected devices.", "IoT Security in the 5G Era", null, 8 },
                    { 8, 14, null, 8, "Penetration testing, also known as ethical hacking, is a critical cybersecurity practice that helps organizations identify vulnerabilities and strengthen their defenses. In this meticulously detailed post, we'll dive deep into the world of penetration testing. Whether you're a cybersecurity professional or a curious IT enthusiast, you'll find valuable insights and best practices to enhance your skills. We'll cover the entire penetration testing lifecycle, from scoping and reconnaissance to exploitation and reporting. You'll learn about various tools and techniques used by penetration testers to uncover security weaknesses in networks, applications, and systems. We'll also discuss the importance of ethical conduct and responsible disclosure in the world of penetration testing. By the end of this post, you'll be well-prepared to embark on your journey as a skilled penetration tester and help secure digital assets.", "Penetration Testing Best Practices", null, 10 },
                    { 9, 3, null, 9, "In the highly competitive world of e-commerce, search engine optimization (SEO) is a game-changer. If you run an online store or plan to launch one, this extensive post is your roadmap to SEO success. We'll take you on a comprehensive journey through the intricate world of e-commerce SEO strategies. From keyword research and on-page optimization to technical SEO and link-building techniques, you'll gain a deep understanding of how to rank higher in search engine results pages (SERPs). We'll also delve into e-commerce-specific SEO challenges and solutions, such as product page optimization and handling duplicate content. Additionally, you'll learn about the latest trends in SEO, including voice search and mobile optimization. By the end of this post, you'll be armed with the knowledge and strategies needed to drive organic traffic and boost sales for your e-commerce business.", "E-Commerce SEO Strategies", null, 11 },
                    { 10, 4, null, 10, "Building mobile apps for multiple platforms can be a daunting task, but it doesn't have to be. Enter Flutter, a powerful and versatile framework for cross-platform mobile app development. In this comprehensive and meticulously crafted post, we'll guide you through the exciting world of Flutter development. Whether you're an experienced app developer or just starting your journey, you'll find valuable insights and hands-on examples to accelerate your mobile app projects. We'll cover the fundamentals of Flutter, including widgets, layouts, and state management, and show you how to create stunning and responsive user interfaces. You'll also learn how to access device features and APIs, handle navigation, and optimize your app's performance. With Flutter's hot reload feature, you'll experience rapid development cycles, making it easier than ever to build and iterate on your app ideas. By the end of this post, you'll have the skills and confidence to develop cross-platform mobile apps that run seamlessly on iOS, Android, and beyond.", "Cross-Platform Mobile App Development with Flutter", null, 12 },
                    { 11, 7, null, 11, "Quantum computing is poised to revolutionize the world of computing, offering unprecedented computational power for solving complex problems. In this in-depth and meticulously researched post, we'll explore the potential applications and challenges of quantum computing. Whether you're a computer scientist, a physicist, or simply curious about the future of technology, you'll find this post enlightening. We'll delve into the core principles of quantum mechanics that underlie quantum computing and explain how qubits, superposition, and entanglement work. You'll also discover the potential impact of quantum computing on various fields, from cryptography and drug discovery to optimization problems and artificial intelligence. However, quantum computing isn't without its challenges, and we'll examine the roadblocks and limitations that researchers face. Join us on this journey into the quantum realm and gain a deep understanding of this groundbreaking technology.", "Quantum Computing: Potential and Challenges", null, 13 },
                    { 12, 5, null, 12, "Creating captivating and enjoyable games is both an art and a science. If you're a game developer or aspiring to be one, this extensive post is a treasure trove of game design principles. We'll explore key principles and strategies that game designers use to create engaging gameplay experiences. From player motivation and game mechanics to level design and storytelling, we'll cover the essential aspects of game design. You'll gain insights into player psychology and learn how to keep players immersed and entertained. We'll also discuss case studies of popular games and dissect what makes them successful. Whether you're developing mobile games, console games, or virtual reality experiences, this post will equip you with the knowledge and techniques to craft memorable and enjoyable games that resonate with players.", "Game Design Principles for Engaging Gameplay", null, 14 },
                    { 13, 9, null, 13, "Image recognition is a fascinating field that has made significant advancements thanks to Convolutional Neural Networks (CNNs). In this extensively detailed post, we'll take you on a deep dive into the world of image recognition using CNNs and deep learning. Whether you're a computer vision enthusiast or a machine learning practitioner, you'll find valuable insights and practical knowledge in this post. We'll start with the basics, covering the inner workings of CNNs, including convolutional layers, pooling, and fully connected layers. You'll also learn about popular deep learning frameworks like TensorFlow and PyTorch, and how to implement CNNs for image recognition tasks. We'll explore real-world use cases, such as object detection, facial recognition, and image classification, showcasing the transformative power of CNNs in various domains. By the end of this post, you'll have the skills and confidence to embark on your image recognition projects and contribute to the advancement of computer vision.", "Image Recognition Using Convolutional Neural Networks", null, 15 },
                    { 14, 1, null, 14, "The world is at a crossroads when it comes to energy consumption and environmental sustainability. Renewable energy sources offer a promising solution to mitigate climate change and ensure a greener and sustainable future. In this meticulously researched post, we'll explore renewable energy solutions and their potential to reshape our energy landscape. Whether you're an environmentalist, an energy professional, or simply curious about the future of energy, you'll find this post enlightening. We'll delve into various renewable energy sources, including solar, wind, hydro, and geothermal power, and discuss their advantages and challenges. You'll also learn about cutting-edge technologies, such as energy storage systems and grid integration, that play a crucial role in harnessing renewable energy. Additionally, we'll examine real-world examples of renewable energy projects and their impact on communities and economies. Join us on this journey to a sustainable future and discover how renewable energy can power the world.", "Renewable Energy Solutions for a Sustainable Future", null, 16 },
                    { 15, 14, null, 15, "Cryptography is the cornerstone of secure communication and data protection in the digital age. In this extensively researched post, we'll explore the role of cryptography in ensuring the confidentiality, integrity, and authenticity of information. Whether you're a cybersecurity professional, a software developer, or simply interested in the science of secrecy, you'll find this post illuminating. We'll start with the fundamentals of cryptography, including encryption algorithms, key management, and digital signatures. You'll gain a deep understanding of how cryptographic techniques work and their applications in various domains, from secure messaging and online banking to digital identity and blockchain technology. We'll also discuss the latest developments in post-quantum cryptography and the challenges posed by quantum computers. By the end of this post, you'll have a solid grasp of cryptography's vital role in modern communication and security.", "Cryptography in Communication and Security", null, 17 },
                    { 16, 1, null, 16, "Artificial Intelligence (AI) is revolutionizing the healthcare industry, offering new possibilities for diagnostics, treatment, and patient care. In this comprehensive post, we'll explore how AI is transforming healthcare and shaping its future. Whether you're a healthcare professional, a data scientist, or simply curious about the intersection of technology and healthcare, you'll find this post enlightening. We'll delve into various applications of AI in healthcare, including medical imaging, predictive analytics, and drug discovery. You'll discover how AI-powered algorithms can analyze medical images with remarkable accuracy and assist in early disease detection. We'll also discuss the ethical considerations and regulatory challenges surrounding AI in healthcare. Additionally, you'll learn about real-world case studies and success stories of AI implementation in hospitals and medical research. Join us on this journey into the world of AI in healthcare and explore the profound impact it's having on patient outcomes and medical advancements.", "The Impact of AI in Healthcare", null, 15 },
                    { 17, 11, null, 17, "Space travel has always captured the imagination of humanity, and it's now closer to reality than ever before. In this extensively researched post, we'll explore the challenges and potential future of space travel, including the ambitious goal of human colonization on Mars. Whether you're a space enthusiast, an aerospace engineer, or simply curious about the cosmos, you'll find this post captivating. We'll delve into the technical and logistical challenges of space travel, from rocket propulsion and radiation protection to life support systems and interplanetary navigation. You'll also learn about the latest developments in space exploration, including the missions to Mars and the search for extraterrestrial life. Additionally, we'll discuss the societal and ethical implications of space travel, including its impact on Earth's environment and the potential for human settlement on other planets. Join us on this cosmic journey and uncover the exciting possibilities and challenges that await us in the final frontier.", "Space Travel: Challenges and Future Prospects", null, 16 },
                    { 18, 8, null, 18, "Blockchain technology, originally designed for cryptocurrencies like Bitcoin, has evolved to find applications in various industries beyond finance. In this meticulously researched post, we'll explore the diverse uses of blockchain technology and how it's reshaping processes and systems. Whether you're a blockchain enthusiast, a business professional, or simply curious about decentralized technologies, you'll find this post illuminating. We'll delve into the fundamental concepts of blockchain, including distributed ledgers, smart contracts, and consensus algorithms. You'll gain insights into how blockchain is transforming supply chain management, healthcare, voting systems, and more. We'll also discuss the challenges and limitations of blockchain, including scalability and regulatory considerations. Additionally, you'll learn about real-world case studies of blockchain implementations and their impact on transparency and security. Join us on this journey to discover the profound impact of blockchain technology beyond cryptocurrency.", "Blockchain Technology: Beyond Cryptocurrency", null, 17 },
                    { 19, 6, null, 19, "3D printing technology has come a long way since its inception, and it's revolutionizing industries ranging from manufacturing to healthcare. In this comprehensive post, we'll explore the recent advancements in 3D printing and their impact on various sectors. Whether you're an engineer, a designer, or simply intrigued by the possibilities of additive manufacturing, you'll find this post enlightening. We'll delve into the core principles of 3D printing, including different printing techniques and materials. You'll discover how 3D printing is transforming industries such as aerospace, automotive, and healthcare, with applications like rapid prototyping, customized medical implants, and even 3D-printed food. We'll also discuss the future of 3D printing, including innovations in multi-material printing and the potential for on-demand manufacturing. By the end of this post, you'll have a deep understanding of the exciting advancements in 3D printing and their implications for the future.", "Advancements in 3D Printing", null, 18 },
                    { 20, 6, null, 20, "The traditional workplace is undergoing a significant transformation, driven by advances in technology and changing attitudes towards work. In this extensively researched post, we'll explore the future of work and how remote and hybrid work models are reshaping the way we work and collaborate. Whether you're a business leader, an HR professional, or an employee navigating the evolving work landscape, you'll find this post insightful. We'll delve into the factors driving the shift towards remote and hybrid work, including the rise of digital tools and the importance of work-life balance. You'll discover strategies for effective remote team management, fostering employee engagement, and maintaining productivity in a remote or hybrid work environment. We'll also discuss the implications of this shift on office space design, corporate culture, and the gig economy. Join us on this exploration of the future of work and gain valuable insights into how organizations and individuals can thrive in the evolving work landscape.", "The Future of Work: Remote and Hybrid Models", null, 19 },
                    { 21, 1, null, 21, "Agriculture plays a pivotal role in feeding the global population, but it also has a significant impact on the environment. In this meticulously researched post, we'll explore sustainable agriculture practices and their importance in ensuring food production while preserving our planet. Whether you're a farmer, an environmentalist, or simply interested in the future of food, you'll find this post enlightening. We'll delve into sustainable farming techniques, including organic farming, crop rotation, and precision agriculture. You'll discover how these practices reduce the environmental footprint of agriculture, conserve natural resources, and promote biodiversity. We'll also discuss the role of technology in sustainable agriculture, from IoT sensors and drones to data analytics and genetic engineering. Additionally, you'll learn about the benefits of sustainable agriculture for farmers, consumers, and the planet as a whole. Join us on this journey to explore the practices that can help feed the world while protecting the Earth.", "Sustainable Agriculture Practices", null, 20 },
                    { 22, 1, null, 22, "The automotive industry is undergoing a profound transformation with the rise of Electric Vehicles (EVs). In this extensively researched post, we'll explore the growth and future prospects of EVs as an eco-friendly and sustainable transportation option. Whether you're an automotive enthusiast, an environmental advocate, or considering an EV for your next vehicle, you'll find this post illuminating. We'll delve into the technology behind electric vehicles, including battery chemistry, charging infrastructure, and electric drivetrains. You'll discover the environmental benefits of EVs, including reduced greenhouse gas emissions and air pollution. We'll also discuss the challenges and opportunities of EV adoption, such as range anxiety and government incentives. Additionally, you'll learn about the latest advancements in EV technology, from autonomous driving features to solid-state batteries. Join us on this journey to explore the electric vehicle revolution and the role it plays in a greener and more sustainable future.", "Rise of Electric Vehicles (EVs)", null, 21 },
                    { 23, 7, null, 23, "Education is evolving, thanks to the integration of Augmented Reality (AR) technology. In this comprehensive post, we'll explore how AR is transforming education and enhancing learning experiences. Whether you're an educator, a student, or simply curious about the future of learning, you'll find this post enlightening. We'll delve into the potential of AR in education, from interactive textbooks and virtual field trips to immersive language learning and laboratory simulations. You'll discover how AR engages students, improves retention, and fosters a deeper understanding of complex subjects. We'll also discuss practical examples of AR applications in different educational settings, from K-12 schools to higher education institutions. Additionally, you'll learn about the challenges and considerations of implementing AR in education, including device compatibility and content creation. Join us on this exploration of Augmented Reality in education and discover the exciting possibilities it offers for learners of all ages.", "Augmented Reality in Education", null, 22 },
                    { 24, 11, null, 24, "The dream of human colonization on Mars has captured the imagination of space enthusiasts and scientists alike. In this meticulously researched post, we'll explore the challenges and possibilities of making Mars colonization a reality. Whether you're a space aficionado, an aerospace engineer, or simply curious about the future of space exploration, you'll find this post captivating. We'll delve into the technical and logistical challenges of sending humans to Mars, including spacecraft design, life support systems, and radiation protection. You'll discover the potential benefits of Mars colonization, from scientific discoveries to the expansion of human civilization beyond Earth. We'll also discuss the ethical and psychological aspects of long-duration space missions and the challenges of sustaining life on the Red Planet. Additionally, you'll learn about the latest developments in Mars exploration, including the missions planned by space agencies and private companies. Join us on this cosmic journey and explore the exciting possibilities and challenges of establishing a human presence on Mars.", "Mars Colonization: Challenges and Possibilities", null, 23 },
                    { 25, 8, null, 25, "The financial industry is undergoing a profound transformation, thanks to the integration of Artificial Intelligence (AI). In this meticulously researched post, we'll explore the role of AI in financial markets, risk assessment, and fraud detection. Whether you're a finance professional, a data scientist, or simply interested in the intersection of technology and finance, you'll find this post illuminating. We'll delve into the various applications of AI in finance, from algorithmic trading and robo-advisors to credit scoring and fraud prevention. You'll discover how AI-powered algorithms analyze vast datasets with speed and precision, making informed decisions in milliseconds. We'll also discuss the challenges and ethical considerations of AI in finance, including bias and transparency. Additionally, you'll learn about the regulatory landscape and the future of AI in the financial industry. Join us on this exploration of Artificial Intelligence in finance and uncover the transformative impact it's having on the world of money.", "Artificial Intelligence in Finance", null, 1 },
                    { 26, 11, null, 26, "User Experience (UX) design has evolved significantly in recent years, shaping the way we interact with digital products and services. In this comprehensive post, we'll explore the evolution of UX design principles and their impact on user interfaces. Whether you're a UX designer, a product manager, or simply curious about the world of design, you'll find this post insightful. We'll delve into the history of UX design, from the early days of usability testing to the emergence of user-centered design principles. You'll discover how user research, information architecture, and usability testing have become integral parts of the design process. We'll also discuss the impact of mobile devices and responsive design on UX, as well as the rise of voice interfaces and conversational UX. Additionally, you'll learn about the latest trends in UX, including augmented reality (AR) and virtual reality (VR) experiences. Join us on this journey through the evolution of UX design and gain a deep understanding of how user-centered principles are shaping the digital world.", "The Evolution of User Experience (UX) Design", null, 2 },
                    { 28, 14, null, 28, "Quantum cryptography is poised to revolutionize data security by harnessing the principles of quantum mechanics to create unbreakable encryption. In this extensively researched post, we'll explore the potential of quantum cryptography and its implications for data protection. Whether you're a cybersecurity professional, a researcher, or simply intrigued by the cutting-edge of cryptography, you'll find this post illuminating. We'll delve into the core concepts of quantum cryptography, including quantum key distribution and quantum-resistant algorithms. You'll discover how quantum properties such as superposition and entanglement can be leveraged to secure communications. We'll also discuss the challenges and limitations of quantum cryptography, including the race to build practical quantum computers and the threat they pose to traditional encryption. Additionally, you'll learn about real-world implementations of quantum cryptography and its use cases in industries like finance and government. Join us on this exploration of the future of data security and uncover how quantum cryptography is reshaping the landscape of encryption.", "The Future of Quantum Cryptography", null, 4 },
                    { 29, 1, null, 29, "Agriculture is undergoing a technological revolution, with innovative solutions reshaping the way we produce food and manage crops. In this comprehensive post, we'll explore the agricultural technology innovations that are increasing efficiency and sustainability in farming. Whether you're a farmer, an agtech enthusiast, or simply interested in the future of agriculture, you'll find this post insightful. We'll delve into cutting-edge technologies, such as precision agriculture, IoT sensors, and autonomous machinery, that are transforming farming practices. You'll discover how data analytics and AI-powered tools optimize crop yield, reduce resource usage, and mitigate environmental impact. We'll also discuss vertical farming and hydroponics as alternative approaches to traditional agriculture, addressing issues of land scarcity and water conservation. Additionally, you'll learn about the role of blockchain in supply chain transparency and food traceability. Join us on this journey through the world of agricultural technology and gain a deeper understanding of how innovation is shaping the future of food production.", "Agricultural Technology Innovations", null, 5 },
                    { 30, 11, null, 30, "The future of urban living is here, and it's smart. In this extensively researched post, we'll explore how smart city technologies are transforming urban environments and improving the quality of life for residents. Whether you're an urban planner, a tech enthusiast, or simply curious about the cities of tomorrow, you'll find this post enlightening. We'll delve into the core components of smart cities, from IoT sensors and data analytics to connected infrastructure and sustainable transportation. You'll discover how smart city initiatives enhance public services, reduce energy consumption, and promote environmental sustainability. We'll also discuss real-world examples of smart city projects around the globe, showcasing the impact of technology on urban development. Additionally, you'll learn about the challenges and considerations of building smart cities, including privacy concerns and digital equity. Join us on this exploration of the future of urban living and discover how smart cities are revolutionizing the way we experience city life.", "Smart Cities: Building the Future", null, 6 },
                    { 31, 8, null, 31, "The rapid advancement of Artificial Intelligence (AI) raises important ethical questions that society must address. In this comprehensive post, we'll explore the ethical considerations surrounding AI development and deployment. Whether you're an AI researcher, an ethicist, or simply interested in the intersection of technology and morality, you'll find this post thought-provoking. We'll delve into the ethical principles that underlie AI, including fairness, transparency, and accountability. You'll discover the challenges posed by biased algorithms, autonomous weapons, and AI-driven decision-making. We'll also discuss the role of regulation and governance in ensuring ethical AI practices and preventing AI misuse. Additionally, you'll learn about the philosophical debates surrounding AI and consciousness, as well as the potential impact of AI on employment and society. Join us on this exploration of the ethical complexities of AI and gain a deeper understanding of the moral questions that AI raises.", "The Ethics of Artificial Intelligence", null, 7 },
                    { 32, 11, null, 32, "Fundamental concepts and components of the React.js library for building user interfaces. Whether you're a seasoned developer or just starting with React, this post will help you grasp the core concepts of this popular JavaScript library. We'll cover topics like components, state, props, and more, giving you a solid foundation to create interactive and dynamic web applications.", "React.js Fundamentals", null, 1 },
                    { 33, 11, null, 33, "Best practices for developing web applications using the Angular framework. Learn how to structure your Angular projects, manage state with NgRx, optimize performance, and deploy your apps with confidence. Whether you're new to Angular or an experienced developer, this post will provide valuable insights into building robust and scalable web applications.", "Angular Development Best Practices", null, 2 },
                    { 35, 11, null, 35, "Optimizing front-end code and assets for improved web performance. Discover techniques to reduce page load times, minimize render-blocking resources, and improve the overall user experience of your web applications. This post covers best practices for optimizing both desktop and mobile web experiences.", "Front-end Performance Optimization", null, 4 },
                    { 36, 12, null, 36, "Developing server-side applications using the Node.js runtime environment. Learn how to create RESTful APIs, handle asynchronous operations, and build scalable server applications with Node.js. This post is a comprehensive guide to Node.js server development.", "Node.js Server Development", null, 1 },
                    { 37, 12, null, 37, "Building web APIs with the Express.js framework in Node.js. Explore the features of Express.js and how it simplifies the process of building robust and efficient web APIs. Whether you're building a RESTful API or a GraphQL server, this post will get you up to speed with Express.js.", "Express.js for Web APIs", null, 2 },
                    { 39, 12, null, 39, "Implementing authentication and security measures in Node.js applications. Explore strategies for user authentication, authorization, and protecting your Node.js applications from common security threats. This post covers best practices for securing your Node.js APIs and applications.", "Authentication and Security in Node.js", null, 4 },
                    { 40, 13, null, 40, "Fundamental concepts of deep learning and neural networks. Dive into the world of artificial intelligence and explore how deep learning models work. This post covers neural networks, activation functions, loss functions, and training algorithms, providing a solid foundation for understanding deep learning.", "Deep Learning Fundamentals", null, 1 },
                    { 41, 13, null, 41, "Exploring NLP techniques and applications in machine learning. Learn how to process and analyze natural language text using machine learning models and libraries. This post covers topics like text classification, sentiment analysis, and language generation, making it a comprehensive guide to NLP.", "Natural Language Processing (NLP)", null, 2 },
                    { 43, 13, null, 43, "Strategies and algorithms for reinforcement learning in AI. Learn how reinforcement learning works, explore algorithms like Q-learning and deep reinforcement learning, and discover practical applications of reinforcement learning in various domains.", "Reinforcement Learning Strategies", null, 4 },
                    { 44, 14, null, 44, "Analyzing network security threats and implementing countermeasures. Explore common network security threats and attacks, and learn how to protect your organization's network infrastructure. This post covers topics like intrusion detection, firewall configuration, and security monitoring.", "Network Security and Threat Analysis", null, 1 },
                    { 45, 14, null, 45, "Exploring ethical hacking techniques and methodologies. Dive into the world of ethical hacking and penetration testing, and learn how to identify and mitigate security vulnerabilities in computer systems and networks. This post covers various hacking tools and techniques.", "Ethical Hacking Techniques", null, 2 },
                    { 47, 14, null, 47, "Developing security policies and ensuring compliance with industry standards. Explore the process of creating and implementing security policies to protect your organization's assets and sensitive data. This post covers compliance frameworks and best practices for security policy development.", "Security Policies and Compliance", null, 4 },
                    { 48, 2, null, 48, "Exploring common data structures and their implementations in Python. This post provides an in-depth overview of various data structures in Python, including lists, sets, dictionaries, and more. Learn how to use these data structures effectively in your Python projects.", "Data Structures in Python", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "PostStatisticsId", "Text", "Title", "TopicOfPostId", "UserId" },
                values: new object[,]
                {
                    { 49, 2, null, 49, "Discussing strategies to optimize algorithms for improved performance. This post covers various optimization techniques and algorithms analysis methods to help you write efficient code and improve the performance of your software applications.", "Algorithm Optimization Techniques", null, 2 },
                    { 51, 2, null, 51, "Fundamental concepts of graph theory and their applications in computer science. Explore the world of graphs, vertices, edges, and graph algorithms. This post covers the basics of graph theory and how it can be used to solve real-world problems in computer science.", "Graph Theory Fundamentals", null, 4 },
                    { 52, 6, null, 52, "Exploring the principles of designing scalable and maintainable software architectures. Learn about software architecture patterns, architectural styles, and best practices for designing software systems that are easy to maintain and scale.", "Software Architecture Principles", null, 1 },
                    { 53, 6, null, 53, "Understanding common design patterns and their use in software development. This post explores various design patterns, such as Singleton, Factory, and Observer, and provides practical examples of how to implement them in your software projects.", "Design Patterns in Software Engineering", null, 2 },
                    { 55, 6, null, 55, "Implementing CI/CD pipelines for automating software development workflows. This post covers the fundamentals of CI/CD, tools like Jenkins and GitLab CI, and best practices for setting up automated build and deployment pipelines.", "Continuous Integration and Deployment (CI/CD)", null, 4 },
                    { 56, 7, null, 56, "Useful tips and tricks for Java programming to enhance your productivity. This post provides a collection of Java programming tips, including coding shortcuts, debugging techniques, and best practices for writing clean and efficient Java code.", "Java Programming Tips and Tricks", null, 1 },
                    { 57, 7, null, 57, "Exploring advanced features and techniques in the C++ programming language. Dive deep into C++ with topics like smart pointers, lambda expressions, and template metaprogramming. This post is a comprehensive guide to advanced C++ programming.", "C++ Language Features and Techniques", null, 2 },
                    { 59, 7, null, 59, "Mastering JavaScript for building interactive web applications. Explore the world of JavaScript, including ES6 features, front-end frameworks like React and Angular, and best practices for building modern web applications.", "Web Development with JavaScript", null, 4 },
                    { 60, 8, null, 60, "Designing efficient and normalized relational databases for applications. Learn about database design principles, normalization, and how to create robust relational database schemas for your software projects.", "Relational Database Design Principles", null, 1 },
                    { 61, 8, null, 61, "Exploring NoSQL databases and their use cases in modern applications. Dive into the world of NoSQL databases, including MongoDB, Cassandra, and Redis. Learn when and how to use them in your applications.", "NoSQL Database Solutions", null, 2 },
                    { 63, 8, null, 63, "Implementing security measures to protect databases from unauthorized access. Discover best practices for securing your databases, including access control, encryption, and auditing.", "Database Security Best Practices", null, 4 },
                    { 64, 10, null, 64, "Embracing DevOps culture and implementing DevOps practices in organizations. Learn how DevOps can streamline software delivery, improve collaboration between teams, and accelerate the development process.", "DevOps Culture and Practices", null, 1 },
                    { 65, 10, null, 65, "Setting up CI pipelines using Jenkins for automated code integration. This post provides a step-by-step guide to setting up Jenkins for continuous integration, automating builds, and deploying applications.", "Continuous Integration with Jenkins", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "TopicsOfPosts",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "PostId", "UserId", "VisibilityStatus" },
                values: new object[,]
                {
                    { 1, 9, "Explore the basics of machine learning and its applications in real-world scenarios.", "Introduction to Machine Learning", 1, 1, "Active" },
                    { 11, 1, "Embark on a cosmic journey to explore the wonders of our universe, from distant galaxies to celestial phenomena.", "Exploring Space and Astronomy", 7, 11, "Active" },
                    { 18, 9, "Learn how machine learning is used to analyze and process human language.", "Machine Learning for Natural Language Processing", 27, 15, "Active" },
                    { 27, 9, "Discover how machine learning models can identify and classify images with high accuracy.", "Machine Learning for Image Recognition", 34, 19, "Active" },
                    { 32, 2, "Comparing various sorting algorithms and their time complexity.", "Sorting Algorithms Comparison", 50, 3, "Active" },
                    { 36, 6, "Best practices for software testing and ensuring software quality.", "Testing and Quality Assurance", 54, 3, "Active" },
                    { 40, 7, "Using Python for data science and machine learning projects.", "Python Programming for Data Science", 58, 3, "Active" },
                    { 44, 8, "Optimizing SQL queries for improved database performance.", "SQL Query Optimization Techniques", 62, 3, "Active" },
                    { 56, 12, "Integrating databases like MongoDB and MySQL with Node.js applications.", "Database Integration with Node.js", 38, 3, "Active" },
                    { 60, 13, "Using deep learning for computer vision and image processing tasks.", "Computer Vision and Image Processing", 42, 3, "Active" },
                    { 64, 14, "Handling security incidents and conducting cyber forensics investigations.", "Incident Response and Cyber Forensics", 46, 3, "Active" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "DislikeCount", "ImageUrl", "LikeCount", "PostId", "PostStatisticsId", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, 0, null, 8, 15, null, "Great post! AI in healthcare has so much potential.", 16 },
                    { 2, 1, null, 6, 16, null, "I've always been fascinated by space travel. Thanks for sharing this.", 17 },
                    { 3, 2, null, 10, 17, null, "Blockchain has the power to change everything. Exciting times ahead!", 18 },
                    { 4, 0, null, 7, 18, null, "3D printing is a game-changer. Can't wait to see what's next.", 19 },
                    { 5, 1, null, 9, 19, null, "Remote work is here to stay. It's convenient and offers more flexibility.", 20 },
                    { 6, 3, null, 11, 20, null, "Sustainability is crucial in agriculture. We need to protect the environment.", 21 },
                    { 7, 2, null, 12, 21, null, "Electric vehicles are the future of transportation. Great article!", 22 },
                    { 8, 1, null, 9, 22, null, "AR in education can make learning more engaging for students.", 23 },
                    { 9, 0, null, 14, 23, null, "Mars colonization would be a monumental achievement for humanity.", 15 },
                    { 10, 2, null, 10, 24, null, "AI is changing the finance industry rapidly. Great insights!", 16 },
                    { 11, 1, null, 11, 25, null, "UX design keeps evolving to create better user experiences.", 12 },
                    { 12, 0, null, 13, 26, null, "Renewable energy storage is critical for a sustainable future.", 14 },
                    { 14, 3, null, 15, 28, null, "Agricultural technology is advancing rapidly. We need more innovation.", 9 },
                    { 15, 2, null, 14, 29, null, "Smart cities are the answer to urban challenges. Great article!", 11 },
                    { 16, 0, null, 16, 30, null, "Ethical AI development is crucial for responsible technology.", 19 },
                    { 17, 1, null, 13, 31, null, "Biotechnology is revolutionizing healthcare and beyond.", 22 },
                    { 18, 3, null, 15, 31, null, "Private companies and government agencies both have roles in space exploration.", 23 },
                    { 19, 2, null, 17, 21, null, "Telemedicine is making healthcare more accessible to remote areas.", 21 }
                });

            migrationBuilder.InsertData(
                table: "TopicsOfPosts",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "PostId", "UserId", "VisibilityStatus" },
                values: new object[,]
                {
                    { 2, 3, "Discover the latest trends and technologies shaping the world of web development in 2023.", "Web Development Trends in 2023", 2, 2, "Active" },
                    { 3, 7, "A step-by-step guide for beginners to start learning Python programming from scratch.", "Beginner's Guide to Python Programming", 4, 3, "Active" },
                    { 4, 14, "Learn essential cybersecurity practices to protect your digital assets and online privacy.", "Cybersecurity Best Practices", 8, 4, "Active" },
                    { 5, 4, "Explore the principles and techniques behind creating visually appealing and user-friendly mobile app interfaces.", "The Art of Mobile App Design", 10, 5, "Active" },
                    { 6, 9, "Delve into how data science can be used to extract valuable insights and drive decision-making in business.", "Data Science for Business Insights", 13, 6, "Active" },
                    { 7, 3, "Dive deep into popular JavaScript frameworks like React, Angular, and Vue.js to build dynamic web applications.", "Mastering JavaScript Frameworks", 16, 7, "Active" },
                    { 8, 1, "Discover tips and tricks for maintaining a healthy lifestyle, including diet, exercise, and stress management.", "Healthy Lifestyle Habits", 5, 8, "Active" },
                    { 9, 1, "Explore adrenaline-pumping travel destinations worldwide for adventure seekers.", "Travel Destinations for Adventure Enthusiasts", 17, 9, "Active" },
                    { 10, 1, "Learn about the world of cryptocurrencies, investment strategies, and the latest developments in the crypto market.", "Investing in Cryptocurrencies", 9, 10, "Active" },
                    { 12, 9, "Explore how AI is transforming the healthcare industry and improving patient care.", "Artificial Intelligence in Healthcare", 31, 12, "Active" },
                    { 13, 11, "Dive into the differences and similarities between frontend and backend development.", "Frontend vs. Backend Development", 11, 13, "Active" },
                    { 14, 5, "Discover the potential applications and advancements in virtual reality technology.", "The Future of Virtual Reality", 3, 14, "Active" },
                    { 15, 9, "Natural Language Processing (NLP) is a fascinating field at the intersection of linguistics and comp", "Natural Language Processing with Python", 15, 6, "Active" },
                    { 16, 3, "Running a high-traffic website comes with its unique set of challenges.", "Scalability Strategies for High-Traffic Websites", 12, 7, "Active" },
                    { 17, 3, "The Internet of Things (IoT) is transforming the way we interact with everyday objects, from smart thermostats to connected cars.", "IoT Security in the 5G Era", 6, 8, "Active" },
                    { 19, 3, "Explore best practices for building web applications that can handle high traffic and scale efficiently.", "Building Scalable Web Applications", 22, 16, "Active" },
                    { 20, 1, "Discuss the implications of 5G technology on the Internet of Things (IoT) ecosystem.", "The Impact of 5G on IoT", 28, 17, "Active" },
                    { 21, 3, "A beginner's guide to creating meaningful visualizations from data.", "Getting Started with Data Visualization", 26, 18, "Active" },
                    { 22, 14, "Learn about ethical hacking practices and how to secure your systems through penetration testing.", "Ethical Hacking and Penetration Testing", 30, 19, "Active" },
                    { 23, 1, "Explore the dynamics of e-commerce, from online marketplaces to digital marketing strategies.", "The World of E-Commerce", 24, 20, "Active" },
                    { 24, 4, "Discover tools and frameworks for developing mobile apps that work on multiple platforms.", "Building Cross-Platform Mobile Apps", 29, 21, "Active" },
                    { 25, 1, "Learn about the principles of quantum computing and its potential to revolutionize computing.", "Introduction to Quantum Computing", 25, 22, "Active" },
                    { 26, 5, "Explore the creative and technical aspects of designing engaging and immersive video games.", "The Art of Game Design", 21, 23, "Active" },
                    { 28, 1, "Discuss sustainable energy options, such as solar, wind, and hydropower, for a greener future.", "Exploring Renewable Energy Sources", 14, 21, "Active" }
                });

            migrationBuilder.InsertData(
                table: "TopicsOfPosts",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "PostId", "UserId", "VisibilityStatus" },
                values: new object[,]
                {
                    { 29, 1, "Dive into the science of encryption and decryption, essential for secure communication and data protection.", "The World of Cryptography", 18, 23, "Active" },
                    { 30, 2, "Exploring common data structures and their implementations in Python.", "Data Structures in Python", 48, 1, "Active" },
                    { 31, 2, "Discussing strategies to optimize algorithms for improved performance.", "Algorithm Optimization Techniques", 49, 2, "Active" },
                    { 33, 2, "Fundamental concepts of graph theory and their applications in computer science.", "Graph Theory Fundamentals", 51, 4, "Active" },
                    { 34, 6, "Exploring the principles of designing scalable and maintainable software architectures.", "Software Architecture Principles", 52, 1, "Active" },
                    { 35, 6, "Understanding common design patterns and their use in software development.", "Design Patterns in Software Engineering", 53, 2, "Active" },
                    { 37, 6, "Implementing CI/CD pipelines for automating software development workflows.", "Continuous Integration and Deployment (CI/CD)", 55, 4, "Active" },
                    { 38, 7, "Useful tips and tricks for Java programming to enhance your productivity.", "Java Programming Tips and Tricks", 56, 1, "Active" },
                    { 39, 7, "Exploring advanced features and techniques in the C++ programming language.", "C++ Language Features and Techniques", 57, 2, "Active" },
                    { 41, 7, "Mastering JavaScript for building interactive web applications.", "Web Development with JavaScript", 59, 4, "Active" },
                    { 42, 8, "Designing efficient and normalized relational databases for applications.", "Relational Database Design Principles", 60, 1, "Active" },
                    { 43, 8, "Exploring NoSQL databases and their use cases in modern applications.", "NoSQL Database Solutions", 61, 2, "Active" },
                    { 45, 8, "Implementing security measures to protect databases from unauthorized access.", "Database Security Best Practices", 63, 4, "Active" },
                    { 46, 10, "Embracing DevOps culture and implementing DevOps practices in organizations.", "DevOps Culture and Practices", 64, 1, "Active" },
                    { 47, 10, "Setting up CI pipelines using Jenkins for automated code integration.", "Continuous Integration with Jenkins", 65, 2, "Active" },
                    { 48, 10, "Using Docker containers for deploying and scaling applications.", "Docker Containers for Deployment", 19, 3, "Active" },
                    { 49, 10, "Managing containerized applications with Kubernetes orchestration.", "Kubernetes Orchestration", 20, 4, "Active" },
                    { 50, 11, "Fundamental concepts and components of the React.js library for building user interfaces.", "React.js Fundamentals", 32, 1, "Active" },
                    { 51, 11, "Best practices for developing web applications using the Angular framework.", "Angular Development Best Practices", 33, 2, "Active" },
                    { 52, 14, "Using Vue.js for state management in front-end applications.", "Vue.js and State Management", 23, 3, "Active" },
                    { 53, 11, "Optimizing front-end code and assets for improved web performance.", "Front-end Performance Optimization", 35, 4, "Active" },
                    { 54, 12, "Developing server-side applications using the Node.js runtime environment.", "Node.js Server Development", 36, 1, "Active" },
                    { 55, 12, "Building web APIs with the Express.js framework in Node.js.", "Express.js for Web APIs", 37, 2, "Active" },
                    { 57, 12, "Implementing authentication and security measures in Node.js applications.", "Authentication and Security in Node.js", 39, 4, "Active" },
                    { 58, 13, "Fundamental concepts of deep learning and neural networks.", "Deep Learning Fundamentals", 40, 1, "Active" },
                    { 59, 13, "Exploring NLP techniques and applications in machine learning.", "Natural Language Processing (NLP)", 41, 2, "Active" },
                    { 61, 13, "Strategies and algorithms for reinforcement learning in AI.", "Reinforcement Learning Strategies", 43, 4, "Active" },
                    { 62, 14, "Analyzing network security threats and implementing countermeasures.", "Network Security and Threat Analysis", 44, 1, "Active" },
                    { 63, 14, "Exploring ethical hacking techniques and methodologies.", "Ethical Hacking Techniques", 45, 2, "Active" },
                    { 65, 14, "Developing security policies and ensuring compliance with industry standards.", "Security Policies and Compliance", 47, 4, "Active" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostStatisticsId",
                table: "Comments",
                column: "PostStatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostStatisticsId",
                table: "Posts",
                column: "PostStatisticsId",
                unique: true,
                filter: "[PostStatisticsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TopicOfPostId",
                table: "Posts",
                column: "TopicOfPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicsOfPosts_CategoryId",
                table: "TopicsOfPosts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicsOfPosts_PostId",
                table: "TopicsOfPosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicsOfPosts_UserId",
                table: "TopicsOfPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PostStatisticsId",
                table: "Users",
                column: "PostStatisticsId",
                unique: true,
                filter: "[PostStatisticsId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_TopicsOfPosts_TopicOfPostId",
                table: "Posts",
                column: "TopicOfPostId",
                principalTable: "TopicsOfPosts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopicsOfPosts_Posts_PostId",
                table: "TopicsOfPosts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "TopicsOfPosts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PostStatistics");
        }
    }
}
