
  using System;
  using System.Collections.Generic;
  
  namespace MudBlocks.Site.Services
  {
	  public static class StaticData
	  {
		  public static List<Database.Block> Blocks { get; } = InitializeBlocks();
		  private static List<Database.Block> InitializeBlocks()
		  {
			try
			{
				return new List<Database.Block> {
				  
					new Database.Block
					{
						Namespace = "Blog.ArticleList",
						AltUrls = new List<string> {  },
						Title = "Article List",
						Description = @"A clean and structured article layout featuring categorized posts with publication dates, detailed descriptions, and 'Learn More' links. Designed for readability and ease of navigation in a modern web design context.",
						Keywords = new List<string> { "Article List", "Categorized Posts", "Structured Layout", "Modern Design", "Responsive Design", "Readability", "Web Components" },
						Authors = new List<BlockService.Author>
						{
							
							new BlockService.Author
							{
								Name = "Mouse0270",
								Url = "https://github.com/mouse0270",
								Image = "https://avatars.githubusercontent.com/u/564874?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mouse0270/"}
								}
							},
							new BlockService.Author
							{
								Name = "Tailblocks",
								Url = "https://github.com/mertJF/tailblocks",
								Image = "https://avatars.githubusercontent.com/u/34642289?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mertJF/"}
								}
							}
						},
						Created = DateOnly.Parse("2024-11-30"),
						Updated = DateOnly.Parse("2024-12-01"),
						Tags = new List<string>()
					},
					new Database.Block
					{
						Namespace = "Blog.BlogTimeline",
						AltUrls = new List<string> {  },
						Title = "Blog Timeline",
						Description = @"A timeline-style blog section featuring categorized posts with publication dates, author avatars, and concise descriptions. Designed for easy navigation and a clean, structured layout.",
						Keywords = new List<string> { "Blog Timeline", "Timeline Design", "Responsive Layout", "Category Posts", "Author Profiles", "Modern Blog Design", "Web Components" },
						Authors = new List<BlockService.Author>
						{
							
							new BlockService.Author
							{
								Name = "Mouse0270",
								Url = "https://github.com/mouse0270",
								Image = "https://avatars.githubusercontent.com/u/564874?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mouse0270/"}
								}
							},
							new BlockService.Author
							{
								Name = "Tailblocks",
								Url = "https://github.com/mertJF/tailblocks",
								Image = "https://avatars.githubusercontent.com/u/34642289?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mertJF/"}
								}
							}
						},
						Created = DateOnly.Parse("2024-12-02"),
						Updated = DateOnly.Parse("2024-12-02"),
						Tags = new List<string>()
					},
					new Database.Block
					{
						Namespace = "Blog.CardLayout",
						AltUrls = new List<string> {  },
						Title = "Card Layout",
						Description = @"A responsive card layout featuring images, titles, descriptions, and action buttons. Includes functionality for view counts, comments, and 'Learn More' links, designed for modern web interfaces.",
						Keywords = new List<string> { "Card Layout", "Responsive Design", "Web Design", "Material Design", "Actionable Cards", "Modern UI", "Blazor Components" },
						Authors = new List<BlockService.Author>
						{
							
							new BlockService.Author
							{
								Name = "Mouse0270",
								Url = "https://github.com/mouse0270",
								Image = "https://avatars.githubusercontent.com/u/564874?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mouse0270/"}
								}
							},
							new BlockService.Author
							{
								Name = "Tailblocks",
								Url = "https://github.com/mertJF/tailblocks",
								Image = "https://avatars.githubusercontent.com/u/34642289?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mertJF/"}
								}
							}
						},
						Created = DateOnly.Parse("2024-12-02"),
						Updated = DateOnly.Parse("2024-12-02"),
						Tags = new List<string>()
					},
					new Database.Block
					{
						Namespace = "Blog.CardsWithHeader",
						AltUrls = new List<string> {  },
						Title = "Cards With Header",
						Description = @"A responsive and engaging blog section featuring tutorials and articles with author profiles, timestamps, and categorized tags. Designed to connect with the audience through structured and accessible content.",
						Keywords = new List<string> { "Blog Header", "Blog Layout", "Responsive Design", "Articles and Tutorials", "Author Profiles", "Content Organization", "Modern Web Design" },
						Authors = new List<BlockService.Author>
						{
							
							new BlockService.Author
							{
								Name = "Mouse0270",
								Url = "https://github.com/mouse0270",
								Image = "https://avatars.githubusercontent.com/u/564874?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mouse0270/"}
								}
							}
						},
						Created = DateOnly.Parse("2024-12-02"),
						Updated = DateOnly.Parse("2024-12-02"),
						Tags = new List<string>()
					},
					new Database.Block
					{
						Namespace = "Blog.CenteredCards",
						AltUrls = new List<string> {  },
						Title = "Centered Cards",
						Description = @"A clean, centered card layout with streamlined content including titles, descriptions, and action buttons. Features view counts, comments, and 'Learn More' links, optimized for a balanced and modern presentation.",
						Keywords = new List<string> { "Card Layout", "Centered Design", "Responsive UI", "Modern Web", "Interactive Cards", "Minimalist Design", "Web Components" },
						Authors = new List<BlockService.Author>
						{
							
							new BlockService.Author
							{
								Name = "Mouse0270",
								Url = "https://github.com/mouse0270",
								Image = "https://avatars.githubusercontent.com/u/564874?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mouse0270/"}
								}
							},
							new BlockService.Author
							{
								Name = "Tailblocks",
								Url = "https://github.com/mertJF/tailblocks",
								Image = "https://avatars.githubusercontent.com/u/34642289?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mertJF/"}
								}
							}
						},
						Created = DateOnly.Parse("2024-12-02"),
						Updated = DateOnly.Parse("2024-12-02"),
						Tags = new List<string>()
					},
					new Database.Block
					{
						Namespace = "Blog.ProfileCards",
						AltUrls = new List<string> {  },
						Title = "Profile Cards",
						Description = @"A modern profile card layout featuring categories, detailed descriptions, view counts, and user information. Includes 'Learn More' links and visually distinct user avatars for better engagement.",
						Keywords = new List<string> { "Profile Cards", "Modern Design", "Responsive Layout", "User Avatars", "Web Design", "Interactive UI", "Card Components" },
						Authors = new List<BlockService.Author>
						{
							
							new BlockService.Author
							{
								Name = "Mouse0270",
								Url = "https://github.com/mouse0270",
								Image = "https://avatars.githubusercontent.com/u/564874?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mouse0270/"}
								}
							},
							new BlockService.Author
							{
								Name = "Tailblocks",
								Url = "https://github.com/mertJF/tailblocks",
								Image = "https://avatars.githubusercontent.com/u/34642289?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mertJF/"}
								}
							}
						},
						Created = DateOnly.Parse("2024-12-02"),
						Updated = DateOnly.Parse("2024-12-02"),
						Tags = new List<string>()
					},
					new Database.Block
					{
						Namespace = "Component.MudNumericSlider",
						AltUrls = new List<string> { "Component/NumericSlider" },
						Title = "Numeric Slider",
						Description = @"This component combines a MudNumericField with a MudSlider to allow users to customize their values easily. The MudNumericField provides a precise input method, while the MudSlider offers a more intuitive and visual way to adjust the values. This combination ensures both accuracy and ease of use, making it ideal for settings where users need to fine-tune numeric values.",
						Keywords = new List<string> { "Numeric Input", "Slider", "MudNumericField", "MudSlider", "User Interface", "Component", "Customization" },
						Authors = new List<BlockService.Author>
						{
							
							new BlockService.Author
							{
								Name = "Mouse0270",
								Url = "https://github.com/mouse0270",
								Image = "https://avatars.githubusercontent.com/u/564874?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mouse0270/"}
								}
							}
						},
						Created = DateOnly.Parse("2024-12-11"),
						
						Tags = new List<string>()
					},
					new Database.Block
					{
						Namespace = "Contact.ContactForm",
						AltUrls = new List<string> {  },
						Title = "Contact Form",
						Description = @"A minimalist contact form layout with fields for name, email, and message. Includes email and physical address details along with social media icons for additional connectivity. Designed for simplicity and accessibility.",
						Keywords = new List<string> { "Contact Form", "Minimalist Design", "Responsive Layout", "User Engagement", "Social Media Integration", "Email Address", "Modern UI" },
						Authors = new List<BlockService.Author>
						{
							
							new BlockService.Author
							{
								Name = "Mouse0270",
								Url = "https://github.com/mouse0270",
								Image = "https://avatars.githubusercontent.com/u/564874?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mouse0270/"}
								}
							},
							new BlockService.Author
							{
								Name = "Tailblocks",
								Url = "https://github.com/mertJF/tailblocks",
								Image = "https://avatars.githubusercontent.com/u/34642289?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mertJF/"}
								}
							}
						},
						Created = DateOnly.Parse("2024-12-03"),
						Updated = DateOnly.Parse("2024-12-03"),
						Tags = new List<string>()
					},
					new Database.Block
					{
						Namespace = "Contact.ContactSection",
						AltUrls = new List<string> {  },
						Title = "Contact Section",
						Description = @"A dynamic contact section combining a map view, contact details, and a feedback form. It includes an address, email, phone number, and fields for user interaction, designed for accessibility and user engagement.",
						Keywords = new List<string> { "Contact Section", "Feedback Form", "Map Integration", "Contact Details", "Responsive Design", "User Engagement", "Modern UI" },
						Authors = new List<BlockService.Author>
						{
							
							new BlockService.Author
							{
								Name = "Mouse0270",
								Url = "https://github.com/mouse0270",
								Image = "https://avatars.githubusercontent.com/u/564874?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mouse0270/"}
								}
							},
							new BlockService.Author
							{
								Name = "Tailblocks",
								Url = "https://github.com/mertJF/tailblocks",
								Image = "https://avatars.githubusercontent.com/u/34642289?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mertJF/"}
								}
							}
						},
						Created = DateOnly.Parse("2024-12-03"),
						Updated = DateOnly.Parse("2024-12-03"),
						Tags = new List<string>()
					},
					new Database.Block
					{
						Namespace = "Contact.FeedbackForm",
						AltUrls = new List<string> {  },
						Title = "Feedback Form",
						Description = @"An interactive feedback form embedded alongside a map view, featuring fields for email and message submission. Designed with privacy and user engagement in mind, this layout ensures accessibility and simplicity.",
						Keywords = new List<string> { "Feedback Form", "Interactive Form", "Map Integration", "User Engagement", "Modern UI", "Responsive Design", "Privacy Focus" },
						Authors = new List<BlockService.Author>
						{
							
							new BlockService.Author
							{
								Name = "Mouse0270",
								Url = "https://github.com/mouse0270",
								Image = "https://avatars.githubusercontent.com/u/564874?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mouse0270/"}
								}
							},
							new BlockService.Author
							{
								Name = "Tailblocks",
								Url = "https://github.com/mertJF/tailblocks",
								Image = "https://avatars.githubusercontent.com/u/34642289?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mertJF/"}
								}
							}
						},
						Created = DateOnly.Parse("2024-12-03"),
						Updated = DateOnly.Parse("2024-12-03"),
						Tags = new List<string>()
					},
					new Database.Block
					{
						Namespace = "Content.Default1",
						AltUrls = new List<string> {  },
						Title = "Default 1",
						Description = @"A simple card with image, title, description and button.",
						Keywords = new List<string> {  },
						Authors = new List<BlockService.Author>
						{
							
							new BlockService.Author
							{
								Name = "Mouse0270",
								Url = "https://github.com/mouse0270",
								Image = "https://avatars.githubusercontent.com/u/564874?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mouse0270/"}
								}
							},
							new BlockService.Author
							{
								Name = "Tailblocks",
								Url = "https://github.com/mertJF/tailblocks",
								Image = "https://avatars.githubusercontent.com/u/34642289?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mertJF/"}
								}
							}
						},
						
						
						Tags = new List<string>()
					},
					new Database.Block
					{
						Namespace = "Content.Default2",
						AltUrls = new List<string> {  },
						Title = "Default 2",
						Description = @"A simple card with image, title, description and button.",
						Keywords = new List<string> {  },
						Authors = new List<BlockService.Author>
						{
							
							new BlockService.Author
							{
								Name = "Mouse0270",
								Url = "https://github.com/mouse0270",
								Image = "https://avatars.githubusercontent.com/u/564874?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mouse0270/"}
								}
							},
							new BlockService.Author
							{
								Name = "Tailblocks",
								Url = "https://github.com/mertJF/tailblocks",
								Image = "https://avatars.githubusercontent.com/u/34642289?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mertJF/"}
								}
							}
						},
						
						
						Tags = new List<string>()
					},
					new Database.Block
					{
						Namespace = "Content.Default3",
						AltUrls = new List<string> {  },
						Title = "Default 3",
						Description = @"A simple card with image, title, description and button.",
						Keywords = new List<string> {  },
						Authors = new List<BlockService.Author>
						{
							
							new BlockService.Author
							{
								Name = "Mouse0270",
								Url = "https://github.com/mouse0270",
								Image = "https://avatars.githubusercontent.com/u/564874?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mouse0270/"}
								}
							},
							new BlockService.Author
							{
								Name = "Tailblocks",
								Url = "https://github.com/mertJF/tailblocks",
								Image = "https://avatars.githubusercontent.com/u/34642289?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mertJF/"}
								}
							}
						},
						
						
						Tags = new List<string>()
					},
					new Database.Block
					{
						Namespace = "Content.Default4",
						AltUrls = new List<string> {  },
						Title = "Default 4",
						Description = @"A simple card with image, title, description and button.",
						Keywords = new List<string> {  },
						Authors = new List<BlockService.Author>
						{
							
							new BlockService.Author
							{
								Name = "Mouse0270",
								Url = "https://github.com/mouse0270",
								Image = "https://avatars.githubusercontent.com/u/564874?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mouse0270/"}
								}
							},
							new BlockService.Author
							{
								Name = "Tailblocks",
								Url = "https://github.com/mertJF/tailblocks",
								Image = "https://avatars.githubusercontent.com/u/34642289?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mertJF/"}
								}
							}
						},
						
						
						Tags = new List<string>()
					},
					new Database.Block
					{
						Namespace = "Content.Default5",
						AltUrls = new List<string> {  },
						Title = "Default 5",
						Description = @"A simple card with image, title, description and button.",
						Keywords = new List<string> {  },
						Authors = new List<BlockService.Author>
						{
							
							new BlockService.Author
							{
								Name = "Mouse0270",
								Url = "https://github.com/mouse0270",
								Image = "https://avatars.githubusercontent.com/u/564874?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mouse0270/"}
								}
							},
							new BlockService.Author
							{
								Name = "Tailblocks",
								Url = "https://github.com/mertJF/tailblocks",
								Image = "https://avatars.githubusercontent.com/u/34642289?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mertJF/"}
								}
							}
						},
						
						
						Tags = new List<string>()
					},
					new Database.Block
					{
						Namespace = "Content.Default6",
						AltUrls = new List<string> {  },
						Title = "Default 6",
						Description = @"A simple card with image, title, description and button.",
						Keywords = new List<string> {  },
						Authors = new List<BlockService.Author>
						{
							
							new BlockService.Author
							{
								Name = "Mouse0270",
								Url = "https://github.com/mouse0270",
								Image = "https://avatars.githubusercontent.com/u/564874?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mouse0270/"}
								}
							},
							new BlockService.Author
							{
								Name = "Tailblocks",
								Url = "https://github.com/mertJF/tailblocks",
								Image = "https://avatars.githubusercontent.com/u/34642289?v=4",
								Socials = new Dictionary<string, string>
								{
									{"GitHub", "https://github.com/mertJF/"}
								}
							}
						},
						
						
						Tags = new List<string>()
					},
					new Database.Block
					{
						Namespace = "Content.Default7",
						AltUrls = new List<string> {  },
						Title = "Default7",
						Description = @"undefined",
						Keywords = new List<string> {  },
						Authors = new List<BlockService.Author>
						{
							
						},
						
						
						Tags = new List<string>()
					},
					new Database.Block
					{
						Namespace = "HeroSection.Default1",
						AltUrls = new List<string> {  },
						Title = "Default1",
						Description = @"undefined",
						Keywords = new List<string> {  },
						Authors = new List<BlockService.Author>
						{
							
						},
						
						
						Tags = new List<string>()
					}
		  		};
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
				return new List<Database.Block>();
			}
		 }
	  }
  }