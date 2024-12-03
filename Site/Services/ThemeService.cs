using MudBlazor;

namespace MudBlocks.Site.Services;

public class ThemeService {
	private bool _isDarkMode = false;
	private string _color = "DeepPurple";
	private string _mode = "Monochromatic";
	private string _font = "Roboto";
	public string Color {
		get => _color;
		set
		{
			if (_color != value)
			{
				_color = value;
				OnThemeChanged?.Invoke(_isDarkMode, value, _mode, _font);
			}
		}
	}
	public string Mode {
		get => _mode;
		set
		{
			if (_mode != value)
			{
				_mode = value;
				OnThemeChanged?.Invoke(_isDarkMode, _color, value, _font);
			}
		}
	}
    public bool IsDarkMode
    {
        get => _isDarkMode;
        set
        {
            if (_isDarkMode != value)
            {
                _isDarkMode = value;
                OnThemeChanged?.Invoke(value, _color, _mode, _font);
            }
        }
    }
	public string Font {
		get => _font;
		set
		{
			if (_font != value)
			{
				_font = value;
				OnThemeChanged?.Invoke(_isDarkMode, _color, _mode, value);
			}
		}
	}
	public MudThemeProvider ThemeProvider { get; set; } = default!;
	public MudTheme Theme => new MudTheme() {
		PaletteLight = Themes[_color][_mode].PaletteLight,
		PaletteDark = Themes[_color][_mode].PaletteDark,
		Typography = new Typography() {
			Default = new DefaultTypography() {
				FontFamily = Fonts[_font].FontFamily,
			},
		}
	};
	public event Action<bool, string, string, string>? OnThemeChanged = null;

	public string GetColorKey(string color) {
		return Themes.Keys.FirstOrDefault(k => k.Equals(color, StringComparison.OrdinalIgnoreCase)) ?? Color;
	}
	public string GetModeKey(string mode) {
		return Themes[Color].Keys.FirstOrDefault(k => k.Equals(mode, StringComparison.OrdinalIgnoreCase)) ?? Mode;
	}
	public string GetFontKey(string font) {
		return Fonts.Keys.FirstOrDefault(k => k.Equals(font, StringComparison.OrdinalIgnoreCase)) ?? Font;
	}

	public class FontType {
		public string[] FontFamily { get; set; } = default!;
		public string FontUrl { get; set; } = default!;
	}
	public Dictionary<string, FontType> Fonts = new Dictionary<string, FontType> {
		{
			"Roboto", new FontType {
				FontFamily = new string[] { "Roboto", "serif" },
				FontUrl = "https://fonts.googleapis.com/css2?Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap"
			}
		}, {
			"Albert Sans", new FontType {
				FontFamily = new string[] { "Albert Sans", "Roboto", "sans-serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Albert+Sans:ital,wght@0,100..900;1,100..900&display=swap"	
			}
		}, {
			"Antic Didone", new FontType {
				FontFamily = new string[] { "Antic Didone", "Roboto", "serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Antic+Didone&display=swap"
			}
		}, {
			"Anton", new FontType {
				FontFamily = new string[] { "Anton", "Roboto", "sans-serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Anton&display=swap"
			}
		}, {
			"Arapey", new FontType {
				FontFamily = new string[] { "Arapey", "Roboto", "serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Arapey:ital@0;1&display=swap"
			}
		}, {
			"Arimo", new FontType {
				FontFamily = new string[] { "Arimo", "Roboto", "sans-serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Arimo:ital,wght@0,400..700;1,400..700&display=swap"
			}
		}, {
			"Besley", new FontType {
				FontFamily = new string[] { "Besley", "Roboto", "sans-serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Besley:ital,wght@0,400..900;1,400..900&display=swap"
			}
		}, {
			"Cambay", new FontType {
				FontFamily = new string[] { "Cambay", "Roboto", "sans-serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Cambay:ital,wght@0,400;0,700;1,400;1,700&display=swap"
			}
		}, {
			"Cormorant Garamond", new FontType {
				FontFamily = new string[] { "Cormorant Garamond", "Roboto", "serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Cormorant+Garamond:ital,wght@0,300;0,400;0,500;0,600;0,700;1,300;1,400;1,500;1,600;1,700&display=swap"
			}
		}, {
			"Comic Sans", new FontType {
				FontFamily = new string[] { "Comic Sans MS", "Comic Sans", "Roboto", "cursive" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Comic+Sans&display=swap"
			}
		}, {
			"Crimson Text", new FontType {
				FontFamily = new string[] { "Crimson Text", "Roboto", "serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Crimson+Text:ital,wght@0,400;0,600;0,700;1,400;1,600;1,700&display=swap"
			}
		}, {
			"DM Serif Text", new FontType {
				FontFamily = new string[] { "DM Serif Text", "Roboto", "serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=DM+Serif+Text:ital@0;1&display=swap"
			}
		}, {
			"Fraunces", new FontType {
				FontFamily = new string[] { "Fraunces", "Roboto", "serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Fraunces:ital,opsz,wght@0,9..144,100..900;1,9..144,100..900&display=swap"
			}
		}, {
			"IBM Plex Mono", new FontType {
				FontFamily = new string[] { "IBM Plex Mono", "Roboto", "monospace" },
				FontUrl = "https://fonts.googleapis.com/css2?family=IBM+Plex+Mono:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;1,100;1,200;1,300;1,400;1,500;1,600;1,700&display=swap"
			}
		}, {
			"Inconsolata", new FontType {
				FontFamily = new string[] { "Inconsolata", "Roboto", "monospace" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Inconsolata:wght@200..900&display=swap"
			}
		}, {
			"Inter", new FontType {
				FontFamily = new string[] { "Inter", "Roboto", "sans-serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Inter:ital,opsz,wght@0,14..32,100..900;1,14..32,100..900&display=swap"
			}
		}, {
			"Josefin Sans", new FontType {
				FontFamily = new string[] { "Josefin Sans", "Roboto", "sans-serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Josefin+Sans:ital,wght@0,100..700;1,100..700&display=swap"
			}
		}, {
			"Lato", new FontType {
				FontFamily = new string[] { "Lato", "Roboto", "sans-serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Lato:ital,wght@0,100;0,300;0,400;0,700;0,900;1,100;1,300;1,400;1,700;1,900&display=swap"
			}
		}, {
			"Libre Baskerville", new FontType {
				FontFamily = new string[] { "Libre Baskerville", "Roboto", "serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Libre+Baskerville:ital,wght@0,400;0,700;1,400&display=swap"
			}
		}, {
			"Libre Bodoni", new FontType {
				FontFamily = new string[] { "Libre Bodoni", "Roboto", "serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Libre+Bodoni:ital,wght@0,400..700;1,400..700&display=swap"
			}
		}, {
			"Lora", new FontType {
				FontFamily = new string[] { "Lora", "Roboto", "serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Lora:ital,wght@0,400..700;1,400..700&display=swap"
			}
		}, {
			"Manrope", new FontType {
				FontFamily = new string[] { "Manrope", "Roboto", "sans-serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Manrope:wght@200..800&display=swap"
			}
		}, {
			"Merrieweather", new FontType {
				FontFamily = new string[] { "Merriweather", "Roboto", "serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Merriweather:ital,wght@0,300;0,400;0,700;0,900;1,300;1,400;1,700;1,900&display=swap"
			}
		}, {
			"Montserrat", new FontType {
				FontFamily = new string[] { "Montserrat", "Roboto", "sans-serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap"
			}
		}, {
			"Nanum Myeongjo", new FontType {
				FontFamily = new string[] { "Nanum Myeongjo", "Roboto", "serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Nanum+Myeongjo&display=swap"
			}
		}, {
			"Noto Sans", new FontType {
				FontFamily = new string[] { "Noto Sans", "Roboto", "sans-serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Noto+Sans:ital,wght@0,100..900;1,100..900&display=swap"
			}
		}, {
			"Nunito Sans", new FontType {
				FontFamily = new string[] { "Nunito Sans", "Roboto", "sans-serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Nunito+Sans:ital,opsz,wght@0,6..12,200..1000;1,6..12,200..1000&display=swap"
			}
		}, {
			"Old Standard TT", new FontType {
				FontFamily = new string[] { "Old Standard TT", "Roboto", "serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Old+Standard+TT:ital,wght@0,400;0,700;1,400&display=swap"
			}
		}, {
			"Open Sans", new FontType {
				FontFamily = new string[] { "Open Sans", "Roboto", "sans-serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Open+Sans:ital,wght@0,300..800;1,300..800&display=swap"
			}
		}, {
			"Oswald", new FontType {
				FontFamily = new string[] { "Oswald", "Roboto", "sans-serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Oswald:wght@200..700&display=swap"
			}
		}, {
			"Outfit", new FontType {
				FontFamily = new string[] { "Outfit", "Roboto", "sans-serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Outfit:wght@100..900&display=swap"
			}
		}, {
			"Oxygen", new FontType {
				FontFamily = new string[] { "Oxygen", "Roboto", "sans-serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Oxygen:wght@300;400;700&display=swap"
			}
		}, {
			"Petit Formal Script", new FontType {
				FontFamily = new string[] { "Petit Formal Script", "Roboto", "cursive" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Petit+Formal+Script&display=swap"
			}
		}, {
			"Playfair Display", new FontType {
				FontFamily = new string[] { "Playfair Display", "Roboto", "serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Playfair+Display:ital,wght@0,400..900;1,400..900&display=swap"
			}
		}, {
			"Poppins", new FontType {
				FontFamily = new string[] { "Poppins", "Roboto", "sans-serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap"
			}
		}, {
			"Prata", new FontType {
				FontFamily = new string[] { "Prata", "Roboto", "serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Prata&display=swapp"
			}
		}, {
			"Radley", new FontType {
				FontFamily = new string[] { "Radley", "Roboto", "serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Radley:ital@0;1&display=swap"
			}
		}, {
			"Raleway", new FontType {
				FontFamily = new string[] { "Raleway", "Roboto", "sans-serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Raleway:ital,wght@0,100..900;1,100..900&display=swap"
			}
		}, {
			"Slabo 27px", new FontType {
				FontFamily = new string[] { "Slabo 27px", "Roboto", "serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Slabo+27px&display=swap"
			}
		}, {
			"Source Sans 3", new FontType {
				FontFamily = new string[] { "Source Sans 3", "Roboto", "sans-serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Source+Sans+3:ital,wght@0,200..900;1,200..900&display=swap"
			}
		}, {
			"Syne", new FontType {
				FontFamily = new string[] { "Syne", "Roboto", "sans-serif" },
				FontUrl = "hhttps://fonts.googleapis.com/css2?family=Syne:wght@400..800&display=swap"
			}
		}/*, {
			"Tangerine", new FontType {
				FontFamily = new string[] { "Tangerine", "Roboto", "cursive" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Tangerine:wght@400;700&display=swap"
			}
		}*/, {
			"Tenor Sans", new FontType {
				FontFamily = new string[] { "Tenor Sans", "Roboto", "sans-serif" },
				FontUrl = "https://fonts.googleapis.com/css2?family=Tenor+Sans&display=swap"
			}
		}
	};
	public Dictionary<string, Dictionary<string, MudTheme>> Themes = new Dictionary<string, Dictionary<string, MudTheme>> {
		{
			"Red", new Dictionary<string, MudTheme> {
				{
					"Analogous", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Red.Default,        // Main red
							Secondary = Colors.Pink.Default,    // Pink (analogous to red)
							Tertiary = Colors.Orange.Default,   // Orange (analogous to red)
							AppbarBackground = Colors.Red.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Red.Lighten1,      // Slightly lighter red
							Secondary = Colors.Pink.Lighten2,  // Lighter pink
							Tertiary = Colors.Orange.Darken2,  // Darker orange
							AppbarBackground = Colors.Red.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Monochromatic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Red.Default,        // Main red
							Secondary = Colors.Red.Lighten2,    // Slightly lighter red
							Tertiary = Colors.Red.Darken2,     // Slightly darker red
							AppbarBackground = Colors.Red.Default,
							AppbarText = Colors.Shades.White   // Ensure contrast with darker red
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Red.Lighten1,     // Lighter red for dark mode
							Secondary = Colors.Red.Darken3,   // Much darker red
							Tertiary = Colors.Red.Darken1,    // Intermediate shade
							AppbarBackground = Colors.Red.Default,
							AppbarText = Colors.Shades.White  // Ensure readability
						}
					}
				}, {
					"Triadic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Red.Default,        // Main red
							Secondary = Colors.Blue.Default,    // Blue (triadic to red)
							Tertiary = Colors.Yellow.Default,   // Yellow (triadic to red)
							AppbarBackground = Colors.Red.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Red.Lighten1,       // Slightly lighter red
							Secondary = Colors.Blue.Darken2,    // Darker blue
							Tertiary = Colors.Yellow.Darken2,   // Darker yellow
							AppbarBackground = Colors.Red.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Complementary", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Red.Default,       // Main red
							Secondary = Colors.Cyan.Accent3,   // Complementary cyan
							Tertiary = Colors.Cyan.Lighten2,   // Lighter cyan
							AppbarBackground = Colors.Red.Default,
							AppbarText = Colors.Shades.White   // Ensure contrast with darker red
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Red.Lighten1,     // Slightly lighter red for dark mode
							Secondary = Colors.Cyan.Darken2,  // Complementary, darker cyan
							Tertiary = Colors.Cyan.Darken3,   // Even darker cyan
							AppbarBackground = Colors.Red.Default,
							AppbarText = Colors.Shades.White  // Ensure readability
						}
					}
				}, {
					"Tetradic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Red.Default,        // Main red
							Secondary = Colors.Green.Default,   // Green (complementary to red)
							Tertiary = Colors.Blue.Default,     // Blue (additional color)
							AppbarBackground = Colors.Red.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Red.Lighten1,       // Slightly lighter red
							Secondary = Colors.Green.Darken2,   // Darker green
							Tertiary = Colors.Blue.Darken2,     // Darker blue
							AppbarBackground = Colors.Red.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}
			}
		}, {
			"Pink", new Dictionary<string, MudTheme> {
				{
					"Analogous", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Pink.Default,      // Main pink
							Secondary = Colors.Purple.Default,  // Purple (analogous to pink)
							Tertiary = Colors.Red.Default,      // Red (analogous to pink)
							AppbarBackground = Colors.Pink.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Pink.Lighten1,     // Slightly lighter pink
							Secondary = Colors.Purple.Darken2, // Darker purple
							Tertiary = Colors.Red.Darken3,     // Darker red
							AppbarBackground = Colors.Pink.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Monochromatic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Pink.Default,      // Main pink
							Secondary = Colors.Pink.Lighten2,   // Lighter pink
							Tertiary = Colors.Pink.Darken2,     // Darker pink
							AppbarBackground = Colors.Pink.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Pink.Lighten1,     // Slightly lighter pink
							Secondary = Colors.Pink.Darken3,   // Much darker pink
							Tertiary = Colors.Pink.Darken1,    // Intermediate shade
							AppbarBackground = Colors.Pink.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Triadic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Pink.Default,      // Main pink
							Secondary = Colors.Green.Default,   // Green (triadic to pink)
							Tertiary = Colors.Orange.Default,   // Orange (triadic to pink)
							AppbarBackground = Colors.Pink.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Pink.Lighten1,     // Slightly lighter pink
							Secondary = Colors.Green.Darken2,  // Darker green
							Tertiary = Colors.Orange.Darken3,  // Darker orange
							AppbarBackground = Colors.Pink.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Complementary", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Pink.Default,      // Main pink
							Secondary = Colors.Green.Default,   // Complementary green
							Tertiary = Colors.Green.Lighten2,   // Lighter green
							AppbarBackground = Colors.Pink.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Pink.Lighten1,     // Slightly lighter pink
							Secondary = Colors.Green.Darken2,  // Darker green
							Tertiary = Colors.Green.Darken3,   // Even darker green
							AppbarBackground = Colors.Pink.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Tetradic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Pink.Default,      // Main pink
							Secondary = Colors.Green.Default,   // Green (complementary to pink)
							Tertiary = Colors.Blue.Default,     // Blue (additional color)
							AppbarBackground = Colors.Pink.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Pink.Lighten1,     // Slightly lighter pink
							Secondary = Colors.Green.Darken2,  // Darker green
							Tertiary = Colors.Blue.Darken2,    // Darker blue
							AppbarBackground = Colors.Pink.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}
			}
		}, {
			"Purple", new Dictionary<string, MudTheme> {
				{
					"Analogous", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Purple.Default,    // Main purple
							Secondary = Colors.Blue.Default,    // Blue (analogous to purple)
							Tertiary = Colors.Pink.Default,     // Pink (analogous to purple)
							AppbarBackground = Colors.Purple.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Purple.Lighten1,   // Slightly lighter purple
							Secondary = Colors.Blue.Darken2,   // Darker blue
							Tertiary = Colors.Pink.Darken3,    // Darker pink
							AppbarBackground = Colors.Purple.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Monochromatic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Purple.Default,    // Main purple
							Secondary = Colors.Purple.Lighten2, // Lighter purple
							Tertiary = Colors.Purple.Darken2,   // Darker purple
							AppbarBackground = Colors.Purple.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Purple.Lighten1,   // Slightly lighter purple
							Secondary = Colors.Purple.Darken3, // Much darker purple
							Tertiary = Colors.Purple.Darken1,  // Intermediate shade
							AppbarBackground = Colors.Purple.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Triadic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Purple.Default,    // Main purple
							Secondary = Colors.Orange.Default, // Orange (triadic to purple)
							Tertiary = Colors.Green.Default,    // Green (triadic to purple)
							AppbarBackground = Colors.Purple.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Purple.Lighten1,   // Slightly lighter purple
							Secondary = Colors.Orange.Darken2, // Darker orange
							Tertiary = Colors.Green.Darken2,   // Darker green
							AppbarBackground = Colors.Purple.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Complementary", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Purple.Default,    // Main purple
							Secondary = Colors.Yellow.Default,  // Complementary yellow
							Tertiary = Colors.Yellow.Lighten2,  // Lighter yellow
							AppbarBackground = Colors.Purple.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Purple.Lighten1,   // Slightly lighter purple
							Secondary = Colors.Yellow.Darken2, // Darker yellow
							Tertiary = Colors.Yellow.Darken3,  // Even darker yellow
							AppbarBackground = Colors.Purple.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Tetradic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Purple.Default,    // Main purple
							Secondary = Colors.Yellow.Default,  // Yellow (complementary to purple)
							Tertiary = Colors.Green.Default,    // Green (additional color)
							AppbarBackground = Colors.Purple.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Purple.Lighten1,   // Slightly lighter purple
							Secondary = Colors.Yellow.Darken2, // Darker yellow
							Tertiary = Colors.Green.Darken2,   // Darker green
							AppbarBackground = Colors.Purple.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}
			}
		}, {
			"DeepPurple", new Dictionary<string, MudTheme> {
				{
					"Analogous", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.DeepPurple.Default, // Main deep purple
							Secondary = Colors.Blue.Default,     // Blue (analogous to deep purple)
							Tertiary = Colors.Pink.Default,      // Pink (analogous to deep purple)
							AppbarBackground = Colors.DeepPurple.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.DeepPurple.Lighten1, // Slightly lighter deep purple
							Secondary = Colors.Blue.Darken2,     // Darker blue
							Tertiary = Colors.Pink.Darken3,      // Darker pink
							AppbarBackground = Colors.DeepPurple.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Monochromatic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.DeepPurple.Default, // Main deep purple
							Secondary = Colors.DeepPurple.Lighten2, // Lighter deep purple
							Tertiary = Colors.DeepPurple.Darken2,   // Darker deep purple
							AppbarBackground = Colors.DeepPurple.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.DeepPurple.Lighten1, // Slightly lighter deep purple
							Secondary = Colors.DeepPurple.Darken3, // Much darker deep purple
							Tertiary = Colors.DeepPurple.Darken1,  // Intermediate shade
							AppbarBackground = Colors.DeepPurple.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Triadic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.DeepPurple.Default, // Main deep purple
							Secondary = Colors.Green.Default,    // Green (triadic to deep purple)
							Tertiary = Colors.Orange.Default,    // Orange (triadic to deep purple)
							AppbarBackground = Colors.DeepPurple.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.DeepPurple.Lighten1, // Slightly lighter deep purple
							Secondary = Colors.Green.Darken2,    // Darker green
							Tertiary = Colors.Orange.Darken2,    // Darker orange
							AppbarBackground = Colors.DeepPurple.Default,
							AppbarText = Colors.Shades.White
						}
					}
				},  {
					"Complementary", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.DeepPurple.Default, // Main deep purple
							Secondary = Colors.Yellow.Default,   // Complementary yellow
							Tertiary = Colors.Yellow.Lighten2,   // Lighter yellow
							AppbarBackground = Colors.DeepPurple.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.DeepPurple.Lighten1, // Slightly lighter deep purple
							Secondary = Colors.Yellow.Darken2,   // Darker yellow
							Tertiary = Colors.Yellow.Darken3,    // Even darker yellow
							AppbarBackground = Colors.DeepPurple.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Tetradic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.DeepPurple.Default, // Main deep purple
							Secondary = Colors.Yellow.Default,   // Yellow (complementary to deep purple)
							Tertiary = Colors.Green.Default,     // Green (additional color)
							AppbarBackground = Colors.DeepPurple.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.DeepPurple.Lighten1, // Slightly lighter deep purple
							Secondary = Colors.Yellow.Darken2,   // Darker yellow
							Tertiary = Colors.Green.Darken2,     // Darker green
							AppbarBackground = Colors.DeepPurple.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}
			}
		}, {
			"Indigo", new Dictionary<string, MudTheme> {
				{
					"Analogous", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Indigo.Default,    // Main indigo
							Secondary = Colors.Blue.Default,    // Blue (analogous to indigo)
							Tertiary = Colors.Purple.Default,   // Purple (analogous to indigo)
							AppbarBackground = Colors.Indigo.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Indigo.Lighten1,   // Slightly lighter indigo
							Secondary = Colors.Blue.Darken2,   // Darker blue
							Tertiary = Colors.Purple.Darken2,  // Darker purple
							AppbarBackground = Colors.Indigo.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Monochromatic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Indigo.Default,    // Main indigo
							Secondary = Colors.Indigo.Lighten2, // Lighter indigo
							Tertiary = Colors.Indigo.Darken2,   // Darker indigo
							AppbarBackground = Colors.Indigo.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Indigo.Lighten1,   // Slightly lighter indigo
							Secondary = Colors.Indigo.Darken3, // Much darker indigo
							Tertiary = Colors.Indigo.Darken1,  // Intermediate shade
							AppbarBackground = Colors.Indigo.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Triadic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Indigo.Default,    // Main indigo
							Secondary = Colors.Green.Default,   // Green (triadic to indigo)
							Tertiary = Colors.Orange.Default,   // Orange (triadic to indigo)
							AppbarBackground = Colors.Indigo.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Indigo.Lighten1,   // Slightly lighter indigo
							Secondary = Colors.Green.Darken2,  // Darker green
							Tertiary = Colors.Orange.Darken2,  // Darker orange
							AppbarBackground = Colors.Indigo.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Complementary", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Indigo.Default,    // Main indigo
							Secondary = Colors.Yellow.Default,  // Complementary yellow
							Tertiary = Colors.Yellow.Lighten2,  // Lighter yellow
							AppbarBackground = Colors.Indigo.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Indigo.Lighten1,   // Slightly lighter indigo
							Secondary = Colors.Yellow.Darken2, // Darker yellow
							Tertiary = Colors.Yellow.Darken3,  // Even darker yellow
							AppbarBackground = Colors.Indigo.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Tetradic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Indigo.Default,    // Main indigo
							Secondary = Colors.Yellow.Default,  // Yellow (complementary to indigo)
							Tertiary = Colors.Green.Default,    // Green (additional color)
							AppbarBackground = Colors.Indigo.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Indigo.Lighten1,   // Slightly lighter indigo
							Secondary = Colors.Yellow.Darken2, // Darker yellow
							Tertiary = Colors.Green.Darken2,   // Darker green
							AppbarBackground = Colors.Indigo.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}
			}
		}, {
			"Blue", new Dictionary<string, MudTheme> {
				{
					"Analogous", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Blue.Default,      // Main blue
							Secondary = Colors.Teal.Default,    // Teal (analogous to blue)
							Tertiary = Colors.Purple.Default,   // Purple (analogous to blue)
							AppbarBackground = Colors.Blue.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Blue.Lighten1,     // Slightly lighter blue
							Secondary = Colors.Teal.Darken2,   // Darker teal
							Tertiary = Colors.Purple.Darken2,  // Darker purple
							AppbarBackground = Colors.Blue.Default,
							AppbarText = Colors.Shades.White
						}
					}
				},  {
					"Monochromatic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Blue.Default,      // Main blue
							Secondary = Colors.Blue.Lighten2,   // Lighter blue
							Tertiary = Colors.Blue.Darken2,     // Darker blue
							AppbarBackground = Colors.Blue.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Blue.Lighten1,     // Slightly lighter blue
							Secondary = Colors.Blue.Darken3,   // Much darker blue
							Tertiary = Colors.Blue.Darken1,    // Intermediate shade
							AppbarBackground = Colors.Blue.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Triadic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Blue.Default,      // Main blue
							Secondary = Colors.Red.Default,     // Red (triadic to blue)
							Tertiary = Colors.Yellow.Default,   // Yellow (triadic to blue)
							AppbarBackground = Colors.Blue.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Blue.Lighten1,     // Slightly lighter blue
							Secondary = Colors.Red.Darken2,    // Darker red
							Tertiary = Colors.Yellow.Darken2,  // Darker yellow
							AppbarBackground = Colors.Blue.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Complementary", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Blue.Default,      // Main blue
							Secondary = Colors.Orange.Default, // Complementary orange
							Tertiary = Colors.Orange.Lighten2, // Lighter orange
							AppbarBackground = Colors.Blue.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Blue.Lighten1,     // Slightly lighter blue
							Secondary = Colors.Orange.Darken2, // Darker orange
							Tertiary = Colors.Orange.Darken3,  // Even darker orange
							AppbarBackground = Colors.Blue.Default,
							AppbarText = Colors.Shades.White
						}
					}
				},  {
					"Tetradic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Blue.Default,      // Main blue
							Secondary = Colors.Orange.Default, // Orange (complementary to blue)
							Tertiary = Colors.Purple.Default,  // Purple (additional color)
							AppbarBackground = Colors.Blue.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Blue.Lighten1,     // Slightly lighter blue
							Secondary = Colors.Orange.Darken2, // Darker orange
							Tertiary = Colors.Purple.Darken2,  // Darker purple
							AppbarBackground = Colors.Blue.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}
			}
		}, {
			"LightBlue", new Dictionary<string, MudTheme> {
				{
					"Analogous", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.LightBlue.Default, // Main light blue
							Secondary = Colors.Teal.Default,    // Teal (analogous to light blue)
							Tertiary = Colors.Blue.Default,     // Blue (analogous to light blue)
							AppbarBackground = Colors.LightBlue.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.LightBlue.Lighten1, // Slightly lighter light blue
							Secondary = Colors.Teal.Darken2,     // Darker teal
							Tertiary = Colors.Blue.Darken2,      // Darker blue
							AppbarBackground = Colors.LightBlue.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Monochromatic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.LightBlue.Default,  // Main light blue
							Secondary = Colors.LightBlue.Lighten2, // Lighter light blue
							Tertiary = Colors.LightBlue.Darken2,   // Darker light blue
							AppbarBackground = Colors.LightBlue.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.LightBlue.Lighten1,  // Slightly lighter light blue
							Secondary = Colors.LightBlue.Darken3, // Much darker light blue
							Tertiary = Colors.LightBlue.Darken1,  // Intermediate shade
							AppbarBackground = Colors.LightBlue.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Triadic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.LightBlue.Default, // Main light blue
							Secondary = Colors.Orange.Default,  // Orange (triadic to light blue)
							Tertiary = Colors.Purple.Default,   // Purple (triadic to light blue)
							AppbarBackground = Colors.LightBlue.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.LightBlue.Lighten1, // Slightly lighter light blue
							Secondary = Colors.Orange.Darken2,  // Darker orange
							Tertiary = Colors.Purple.Darken2,   // Darker purple
							AppbarBackground = Colors.LightBlue.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Complementary", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.LightBlue.Default, // Main light blue
							Secondary = Colors.Yellow.Default,  // Complementary yellow
							Tertiary = Colors.Yellow.Lighten2,  // Lighter yellow
							AppbarBackground = Colors.LightBlue.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.LightBlue.Lighten1, // Slightly lighter light blue
							Secondary = Colors.Yellow.Darken2,  // Darker yellow
							Tertiary = Colors.Yellow.Darken3,   // Even darker yellow
							AppbarBackground = Colors.LightBlue.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Tetradic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.LightBlue.Default, // Main light blue
							Secondary = Colors.Yellow.Default,  // Yellow (complementary to light blue)
							Tertiary = Colors.Purple.Default,   // Purple (additional color)
							AppbarBackground = Colors.LightBlue.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.LightBlue.Lighten1, // Slightly lighter light blue
							Secondary = Colors.Yellow.Darken2,  // Darker yellow
							Tertiary = Colors.Purple.Darken2,   // Darker purple
							AppbarBackground = Colors.LightBlue.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}
			}
		}, {
			"Cyan", new Dictionary<string, MudTheme> {
				{
					"Analogous", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Cyan.Default,      // Main cyan
							Secondary = Colors.Blue.Default,    // Blue (analogous to cyan)
							Tertiary = Colors.Teal.Default,     // Teal (analogous to cyan)
							AppbarBackground = Colors.Cyan.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Cyan.Lighten1,     // Slightly lighter cyan
							Secondary = Colors.Blue.Darken2,   // Darker blue
							Tertiary = Colors.Teal.Darken2,    // Darker teal
							AppbarBackground = Colors.Cyan.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Monochromatic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Cyan.Default,      // Main cyan
							Secondary = Colors.Cyan.Lighten2,   // Lighter cyan
							Tertiary = Colors.Cyan.Darken2,     // Darker cyan
							AppbarBackground = Colors.Cyan.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Cyan.Lighten1,     // Slightly lighter cyan
							Secondary = Colors.Cyan.Darken3,   // Much darker cyan
							Tertiary = Colors.Cyan.Darken1,    // Intermediate shade
							AppbarBackground = Colors.Cyan.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Triadic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Cyan.Default,      // Main cyan
							Secondary = Colors.Pink.Default,    // Pink (triadic to cyan)
							Tertiary = Colors.Yellow.Default,   // Yellow (triadic to cyan)
							AppbarBackground = Colors.Cyan.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Cyan.Lighten1,     // Slightly lighter cyan
							Secondary = Colors.Pink.Darken2,   // Darker pink
							Tertiary = Colors.Yellow.Darken2,  // Darker yellow
							AppbarBackground = Colors.Cyan.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Complementary", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Cyan.Default,      // Main cyan
							Secondary = Colors.Red.Default,     // Complementary red
							Tertiary = Colors.Red.Lighten2,     // Lighter red
							AppbarBackground = Colors.Cyan.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Cyan.Lighten1,     // Slightly lighter cyan
							Secondary = Colors.Red.Darken2,    // Darker red
							Tertiary = Colors.Red.Darken3,     // Even darker red
							AppbarBackground = Colors.Cyan.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Tetradic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Cyan.Default,      // Main cyan
							Secondary = Colors.Red.Default,     // Red (complementary to cyan)
							Tertiary = Colors.Yellow.Default,   // Yellow (additional color)
							AppbarBackground = Colors.Cyan.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Cyan.Lighten1,     // Slightly lighter cyan
							Secondary = Colors.Red.Darken2,    // Darker red
							Tertiary = Colors.Yellow.Darken2,  // Darker yellow
							AppbarBackground = Colors.Cyan.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}
			}
		}, {
			"Teal", new Dictionary<string, MudTheme> {
				{
					"Analogous", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Teal.Default,      // Main teal
							Secondary = Colors.Cyan.Default,    // Cyan (analogous to teal)
							Tertiary = Colors.Green.Default,    // Green (analogous to teal)
							AppbarBackground = Colors.Teal.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Teal.Lighten1,     // Slightly lighter teal
							Secondary = Colors.Cyan.Darken2,   // Darker cyan
							Tertiary = Colors.Green.Darken2,   // Darker green
							AppbarBackground = Colors.Teal.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Monochromatic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Teal.Default,      // Main teal
							Secondary = Colors.Teal.Lighten2,   // Lighter teal
							Tertiary = Colors.Teal.Darken2,     // Darker teal
							AppbarBackground = Colors.Teal.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Teal.Lighten1,     // Slightly lighter teal
							Secondary = Colors.Teal.Darken3,   // Much darker teal
							Tertiary = Colors.Teal.Darken1,    // Intermediate shade
							AppbarBackground = Colors.Teal.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Triadic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Teal.Default,      // Main teal
							Secondary = Colors.Orange.Default, // Orange (triadic to teal)
							Tertiary = Colors.Purple.Default,  // Purple (triadic to teal)
							AppbarBackground = Colors.Teal.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Teal.Lighten1,     // Slightly lighter teal
							Secondary = Colors.Orange.Darken2, // Darker orange
							Tertiary = Colors.Purple.Darken2,  // Darker purple
							AppbarBackground = Colors.Teal.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Complementary", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Teal.Default,      // Main teal
							Secondary = Colors.Red.Default,     // Complementary red
							Tertiary = Colors.Red.Lighten2,     // Lighter red
							AppbarBackground = Colors.Teal.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Teal.Lighten1,     // Slightly lighter teal
							Secondary = Colors.Red.Darken2,    // Darker red
							Tertiary = Colors.Red.Darken3,     // Even darker red
							AppbarBackground = Colors.Teal.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Tetradic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Teal.Default,      // Main teal
							Secondary = Colors.Red.Default,     // Red (complementary to teal)
							Tertiary = Colors.Orange.Default,   // Orange (additional color)
							AppbarBackground = Colors.Teal.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Teal.Lighten1,     // Slightly lighter teal
							Secondary = Colors.Red.Darken2,    // Darker red
							Tertiary = Colors.Orange.Darken2,  // Darker orange
							AppbarBackground = Colors.Teal.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}
			}
		}, {
			"Green", new Dictionary<string, MudTheme> {
				{
					"Analogous", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Green.Default,      // Main green
							Secondary = Colors.Teal.Default,     // Teal (analogous to green)
							Tertiary = Colors.Lime.Default,      // Lime (analogous to green)
							AppbarBackground = Colors.Green.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Green.Lighten1,     // Slightly lighter green
							Secondary = Colors.Teal.Darken2,    // Darker teal
							Tertiary = Colors.Lime.Darken2,     // Darker lime
							AppbarBackground = Colors.Green.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Monochromatic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Green.Default,      // Main green
							Secondary = Colors.Green.Lighten2,   // Lighter green
							Tertiary = Colors.Green.Darken2,     // Darker green
							AppbarBackground = Colors.Green.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Green.Lighten1,     // Slightly lighter green
							Secondary = Colors.Green.Darken3,   // Much darker green
							Tertiary = Colors.Green.Darken1,    // Intermediate shade
							AppbarBackground = Colors.Green.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Triadic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Green.Default,      // Main green
							Secondary = Colors.Purple.Default,   // Purple (triadic to green)
							Tertiary = Colors.Orange.Default,    // Orange (triadic to green)
							AppbarBackground = Colors.Green.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Green.Lighten1,     // Slightly lighter green
							Secondary = Colors.Purple.Darken2,  // Darker purple
							Tertiary = Colors.Orange.Darken2,   // Darker orange
							AppbarBackground = Colors.Green.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Complementary", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Green.Default,      // Main green
							Secondary = Colors.Red.Default,      // Complementary red
							Tertiary = Colors.Red.Lighten2,      // Lighter red
							AppbarBackground = Colors.Green.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Green.Lighten1,     // Slightly lighter green
							Secondary = Colors.Red.Darken2,     // Darker red
							Tertiary = Colors.Red.Darken3,      // Even darker red
							AppbarBackground = Colors.Green.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Tetradic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Green.Default,      // Main green
							Secondary = Colors.Red.Default,      // Red (complementary to green)
							Tertiary = Colors.Teal.Default,      // Teal (additional color)
							AppbarBackground = Colors.Green.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Green.Lighten1,     // Slightly lighter green
							Secondary = Colors.Red.Darken2,     // Darker red
							Tertiary = Colors.Teal.Darken2,     // Darker teal
							AppbarBackground = Colors.Green.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}
			}
		}, {
			"LightGreen", new Dictionary<string, MudTheme> {
				{
					"Analogous", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.LightGreen.Default,  // Main light green
							Secondary = Colors.Green.Default,     // Green (analogous to light green)
							Tertiary = Colors.Lime.Default,       // Lime (analogous to light green)
							AppbarBackground = Colors.LightGreen.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.LightGreen.Lighten1, // Slightly lighter light green
							Secondary = Colors.Green.Darken2,    // Darker green
							Tertiary = Colors.Lime.Darken2,      // Darker lime
							AppbarBackground = Colors.LightGreen.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Monochromatic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.LightGreen.Default,  // Main light green
							Secondary = Colors.LightGreen.Lighten2, // Lighter light green
							Tertiary = Colors.LightGreen.Darken2,   // Darker light green
							AppbarBackground = Colors.LightGreen.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.LightGreen.Lighten1, // Slightly lighter light green
							Secondary = Colors.LightGreen.Darken3, // Much darker light green
							Tertiary = Colors.LightGreen.Darken1,  // Intermediate shade
							AppbarBackground = Colors.LightGreen.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Triadic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.LightGreen.Default,  // Main light green
							Secondary = Colors.Orange.Default,    // Orange (triadic to light green)
							Tertiary = Colors.Purple.Default,     // Purple (triadic to light green)
							AppbarBackground = Colors.LightGreen.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.LightGreen.Lighten1, // Slightly lighter light green
							Secondary = Colors.Orange.Darken2,   // Darker orange
							Tertiary = Colors.Purple.Darken2,    // Darker purple
							AppbarBackground = Colors.LightGreen.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Complementary", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.LightGreen.Default,  // Main light green
							Secondary = Colors.Red.Default,       // Complementary red
							Tertiary = Colors.Red.Lighten2,       // Lighter red
							AppbarBackground = Colors.LightGreen.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.LightGreen.Lighten1, // Slightly lighter light green
							Secondary = Colors.Red.Darken2,      // Darker red
							Tertiary = Colors.Red.Darken3,       // Even darker red
							AppbarBackground = Colors.LightGreen.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Tetradic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.LightGreen.Default,  // Main light green
							Secondary = Colors.Red.Default,       // Red (complementary to light green)
							Tertiary = Colors.Green.Default,      // Green (additional color)
							AppbarBackground = Colors.LightGreen.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.LightGreen.Lighten1, // Slightly lighter light green
							Secondary = Colors.Red.Darken2,      // Darker red
							Tertiary = Colors.Green.Darken2,     // Darker green
							AppbarBackground = Colors.LightGreen.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}
			}
		}, {
			"Lime", new Dictionary<string, MudTheme> {
				{
					"Analogous", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Lime.Default,       // Main lime
							Secondary = Colors.Green.Default,    // Green (analogous to lime)
							Tertiary = Colors.Yellow.Default,    // Yellow (analogous to lime)
							AppbarBackground = Colors.Lime.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Lime.Lighten1,      // Slightly lighter lime
							Secondary = Colors.Green.Darken2,   // Darker green
							Tertiary = Colors.Yellow.Darken2,   // Darker yellow
							AppbarBackground = Colors.Lime.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Monochromatic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Lime.Default,       // Main lime
							Secondary = Colors.Lime.Lighten2,    // Lighter lime
							Tertiary = Colors.Lime.Darken2,      // Darker lime
							AppbarBackground = Colors.Lime.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Lime.Lighten1,      // Slightly lighter lime
							Secondary = Colors.Lime.Darken3,    // Much darker lime
							Tertiary = Colors.Lime.Darken1,     // Intermediate shade
							AppbarBackground = Colors.Lime.Default,
							AppbarText = Colors.Shades.White
						}
					}
				},{
					"Triadic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Lime.Default,       // Main lime
							Secondary = Colors.Purple.Default,   // Purple (triadic to lime)
							Tertiary = Colors.Orange.Default,    // Orange (triadic to lime)
							AppbarBackground = Colors.Lime.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Lime.Lighten1,      // Slightly lighter lime
							Secondary = Colors.Purple.Darken2,  // Darker purple
							Tertiary = Colors.Orange.Darken2,   // Darker orange
							AppbarBackground = Colors.Lime.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Complementary", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Lime.Default,       // Main lime
							Secondary = Colors.DeepPurple.Default, // Complementary deep purple
							Tertiary = Colors.DeepPurple.Lighten2, // Lighter deep purple
							AppbarBackground = Colors.Lime.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Lime.Lighten1,      // Slightly lighter lime
							Secondary = Colors.DeepPurple.Darken2, // Darker deep purple
							Tertiary = Colors.DeepPurple.Darken3, // Even darker deep purple
							AppbarBackground = Colors.Lime.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Tetradic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Lime.Default,       // Main lime
							Secondary = Colors.DeepPurple.Default, // Deep purple (complementary to lime)
							Tertiary = Colors.Orange.Default,    // Orange (additional color)
							AppbarBackground = Colors.Lime.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Lime.Lighten1,      // Slightly lighter lime
							Secondary = Colors.DeepPurple.Darken2, // Darker deep purple
							Tertiary = Colors.Orange.Darken2,   // Darker orange
							AppbarBackground = Colors.Lime.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}
			}
		}, {
			"Yellow", new Dictionary<string, MudTheme> {
				{
					"Analogous", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Yellow.Default,      // Main yellow
							Secondary = Colors.Lime.Default,      // Lime (analogous to yellow)
							Tertiary = Colors.Orange.Default,     // Orange (analogous to yellow)
							AppbarBackground = Colors.Yellow.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Yellow.Lighten1,     // Slightly lighter yellow
							Secondary = Colors.Lime.Darken2,     // Darker lime
							Tertiary = Colors.Orange.Darken2,    // Darker orange
							AppbarBackground = Colors.Yellow.Default,
							AppbarText = Colors.Shades.Black
						}
					}
				}, {
					"Monochromatic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Yellow.Default,      // Main yellow
							Secondary = Colors.Yellow.Lighten2,   // Lighter yellow
							Tertiary = Colors.Yellow.Darken2,     // Darker yellow
							AppbarBackground = Colors.Yellow.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Yellow.Lighten1,     // Slightly lighter yellow
							Secondary = Colors.Yellow.Darken3,   // Much darker yellow
							Tertiary = Colors.Yellow.Darken1,    // Intermediate shade
							AppbarBackground = Colors.Yellow.Default,
							AppbarText = Colors.Shades.Black
						}
					}
				}, {
					"Triadic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Yellow.Default,      // Main yellow
							Secondary = Colors.Blue.Default,      // Blue (triadic to yellow)
							Tertiary = Colors.Red.Default,        // Red (triadic to yellow)
							AppbarBackground = Colors.Yellow.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Yellow.Lighten1,     // Slightly lighter yellow
							Secondary = Colors.Blue.Darken2,     // Darker blue
							Tertiary = Colors.Red.Darken2,       // Darker red
							AppbarBackground = Colors.Yellow.Default,
							AppbarText = Colors.Shades.Black
						}
					}
				}, {
					"Complementary", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Yellow.Default,      // Main yellow
							Secondary = Colors.Blue.Default,      // Complementary blue
							Tertiary = Colors.Blue.Lighten2,      // Lighter blue
							AppbarBackground = Colors.Yellow.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Yellow.Lighten1,     // Slightly lighter yellow
							Secondary = Colors.Blue.Darken2,     // Darker blue
							Tertiary = Colors.Blue.Darken3,      // Even darker blue
							AppbarBackground = Colors.Yellow.Default,
							AppbarText = Colors.Shades.Black
						}
					}
				}, {
					"Tetradic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Yellow.Default,      // Main yellow
							Secondary = Colors.Blue.Default,      // Blue (complementary to yellow)
							Tertiary = Colors.Orange.Default,     // Orange (additional color)
							AppbarBackground = Colors.Yellow.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Yellow.Lighten1,     // Slightly lighter yellow
							Secondary = Colors.Blue.Darken2,     // Darker blue
							Tertiary = Colors.Orange.Darken2,    // Darker orange
							AppbarBackground = Colors.Yellow.Default,
							AppbarText = Colors.Shades.Black
						}
					}
				}
			}
		}, {
			"Amber", new Dictionary<string, MudTheme> {
				{
					"Analogous", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Amber.Default,      // Main amber
							Secondary = Colors.Orange.Default,   // Orange (analogous to amber)
							Tertiary = Colors.Yellow.Default,    // Yellow (analogous to amber)
							AppbarBackground = Colors.Amber.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Amber.Lighten1,     // Slightly lighter amber
							Secondary = Colors.Orange.Darken2,  // Darker orange
							Tertiary = Colors.Yellow.Darken2,   // Darker yellow
							AppbarBackground = Colors.Amber.Default,
							AppbarText = Colors.Shades.Black
						}
					}
				}, {
					"Monochromatic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Amber.Default,      // Main amber
							Secondary = Colors.Amber.Lighten2,   // Lighter amber
							Tertiary = Colors.Amber.Darken2,     // Darker amber
							AppbarBackground = Colors.Amber.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Amber.Lighten1,     // Slightly lighter amber
							Secondary = Colors.Amber.Darken3,   // Much darker amber
							Tertiary = Colors.Amber.Darken1,    // Intermediate shade
							AppbarBackground = Colors.Amber.Default,
							AppbarText = Colors.Shades.Black
						}
					}
				}, {
					"Triadic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Amber.Default,      // Main amber
							Secondary = Colors.Blue.Default,     // Blue (triadic to amber)
							Tertiary = Colors.Green.Default,     // Green (triadic to amber)
							AppbarBackground = Colors.Amber.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Amber.Lighten1,     // Slightly lighter amber
							Secondary = Colors.Blue.Darken2,    // Darker blue
							Tertiary = Colors.Green.Darken2,    // Darker green
							AppbarBackground = Colors.Amber.Default,
							AppbarText = Colors.Shades.Black
						}
					}
				}, {
					"Complementary", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Amber.Default,      // Main amber
							Secondary = Colors.Blue.Default,     // Complementary blue
							Tertiary = Colors.Blue.Lighten2,     // Lighter blue
							AppbarBackground = Colors.Amber.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Amber.Lighten1,     // Slightly lighter amber
							Secondary = Colors.Blue.Darken2,    // Darker blue
							Tertiary = Colors.Blue.Darken3,     // Even darker blue
							AppbarBackground = Colors.Amber.Default,
							AppbarText = Colors.Shades.Black
						}
					}
				}, {
					"Tetradic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Amber.Default,      // Main amber
							Secondary = Colors.Blue.Default,     // Blue (complementary to amber)
							Tertiary = Colors.Green.Default,     // Green (additional color)
							AppbarBackground = Colors.Amber.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Amber.Lighten1,     // Slightly lighter amber
							Secondary = Colors.Blue.Darken2,    // Darker blue
							Tertiary = Colors.Green.Darken2,    // Darker green
							AppbarBackground = Colors.Amber.Default,
							AppbarText = Colors.Shades.Black
						}
					}
				}
			}
		}, {
			"Orange", new Dictionary<string, MudTheme> {
				{
					"Analogous", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Orange.Default,      // Main orange
							Secondary = Colors.Amber.Default,     // Amber (analogous to orange)
							Tertiary = Colors.Red.Default,        // Red (analogous to orange)
							AppbarBackground = Colors.Orange.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Orange.Lighten1,     // Slightly lighter orange
							Secondary = Colors.Amber.Darken2,    // Darker amber
							Tertiary = Colors.Red.Darken2,       // Darker red
							AppbarBackground = Colors.Orange.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Monochromatic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Orange.Default,      // Main orange
							Secondary = Colors.Orange.Lighten2,   // Lighter orange
							Tertiary = Colors.Orange.Darken2,     // Darker orange
							AppbarBackground = Colors.Orange.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Orange.Lighten1,     // Slightly lighter orange
							Secondary = Colors.Orange.Darken3,   // Much darker orange
							Tertiary = Colors.Orange.Darken1,    // Intermediate shade
							AppbarBackground = Colors.Orange.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Triadic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Orange.Default,      // Main orange
							Secondary = Colors.Blue.Default,      // Blue (triadic to orange)
							Tertiary = Colors.Green.Default,      // Green (triadic to orange)
							AppbarBackground = Colors.Orange.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Orange.Lighten1,     // Slightly lighter orange
							Secondary = Colors.Blue.Darken2,     // Darker blue
							Tertiary = Colors.Green.Darken2,     // Darker green
							AppbarBackground = Colors.Orange.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Complementary", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Orange.Default,      // Main orange
							Secondary = Colors.Teal.Default,      // Complementary teal
							Tertiary = Colors.Teal.Lighten2,      // Lighter teal
							AppbarBackground = Colors.Orange.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Orange.Lighten1,     // Slightly lighter orange
							Secondary = Colors.Teal.Darken2,     // Darker teal
							Tertiary = Colors.Teal.Darken3,      // Even darker teal
							AppbarBackground = Colors.Orange.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Tetradic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Orange.Default,      // Main orange
							Secondary = Colors.Teal.Default,      // Teal (complementary to orange)
							Tertiary = Colors.Amber.Default,      // Amber (additional color)
							AppbarBackground = Colors.Orange.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Orange.Lighten1,     // Slightly lighter orange
							Secondary = Colors.Teal.Darken2,     // Darker teal
							Tertiary = Colors.Amber.Darken2,     // Darker amber
							AppbarBackground = Colors.Orange.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}
			}
		}, {
			"DeepOrange", new Dictionary<string, MudTheme> {
				{
					"Analogous", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.DeepOrange.Default, // Main deep orange
							Secondary = Colors.Amber.Default,    // Amber (analogous to deep orange)
							Tertiary = Colors.Red.Default,       // Red (analogous to deep orange)
							AppbarBackground = Colors.DeepOrange.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.DeepOrange.Lighten1, // Slightly lighter deep orange
							Secondary = Colors.Amber.Darken2,    // Darker amber
							Tertiary = Colors.Red.Darken2,       // Darker red
							AppbarBackground = Colors.DeepOrange.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Monochromatic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.DeepOrange.Default, // Main deep orange
							Secondary = Colors.DeepOrange.Lighten2, // Lighter deep orange
							Tertiary = Colors.DeepOrange.Darken2,   // Darker deep orange
							AppbarBackground = Colors.DeepOrange.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.DeepOrange.Lighten1, // Slightly lighter deep orange
							Secondary = Colors.DeepOrange.Darken3, // Much darker deep orange
							Tertiary = Colors.DeepOrange.Darken1,  // Intermediate shade
							AppbarBackground = Colors.DeepOrange.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Triadic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.DeepOrange.Default, // Main deep orange
							Secondary = Colors.Cyan.Default,     // Cyan (triadic to deep orange)
							Tertiary = Colors.Green.Default,     // Green (triadic to deep orange)
							AppbarBackground = Colors.DeepOrange.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.DeepOrange.Lighten1, // Slightly lighter deep orange
							Secondary = Colors.Cyan.Darken2,     // Darker cyan
							Tertiary = Colors.Green.Darken2,     // Darker green
							AppbarBackground = Colors.DeepOrange.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Complementary", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.DeepOrange.Default, // Main deep orange
							Secondary = Colors.Blue.Default,     // Complementary blue
							Tertiary = Colors.Blue.Lighten2,     // Lighter blue
							AppbarBackground = Colors.DeepOrange.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.DeepOrange.Lighten1, // Slightly lighter deep orange
							Secondary = Colors.Blue.Darken2,     // Darker blue
							Tertiary = Colors.Blue.Darken3,      // Even darker blue
							AppbarBackground = Colors.DeepOrange.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Tetradic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.DeepOrange.Default, // Main deep orange
							Secondary = Colors.Blue.Default,     // Blue (complementary to deep orange)
							Tertiary = Colors.Amber.Default,     // Amber (additional color)
							AppbarBackground = Colors.DeepOrange.Default,
							AppbarText = Colors.Shades.Black
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.DeepOrange.Lighten1, // Slightly lighter deep orange
							Secondary = Colors.Blue.Darken2,     // Darker blue
							Tertiary = Colors.Amber.Darken2,     // Darker amber
							AppbarBackground = Colors.DeepOrange.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}
			}
		}, {
			"Brown", new Dictionary<string, MudTheme> {
				{
					"Analogous", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Brown.Default,      // Main brown
							Secondary = Colors.Amber.Default,    // Amber (analogous to brown)
							Tertiary = Colors.DeepOrange.Default, // Deep Orange (analogous to brown)
							AppbarBackground = Colors.Brown.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Brown.Lighten1,     // Slightly lighter brown
							Secondary = Colors.Amber.Darken2,   // Darker amber
							Tertiary = Colors.DeepOrange.Darken2, // Darker deep orange
							AppbarBackground = Colors.Brown.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Monochromatic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Brown.Default,      // Main brown
							Secondary = Colors.Brown.Lighten2,   // Lighter brown
							Tertiary = Colors.Brown.Darken2,     // Darker brown
							AppbarBackground = Colors.Brown.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Brown.Lighten1,     // Slightly lighter brown
							Secondary = Colors.Brown.Darken3,   // Much darker brown
							Tertiary = Colors.Brown.Darken1,    // Intermediate shade
							AppbarBackground = Colors.Brown.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Triadic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Brown.Default,      // Main brown
							Secondary = Colors.Blue.Default,     // Blue (triadic to brown)
							Tertiary = Colors.Green.Default,     // Green (triadic to brown)
							AppbarBackground = Colors.Brown.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Brown.Lighten1,     // Slightly lighter brown
							Secondary = Colors.Blue.Darken2,    // Darker blue
							Tertiary = Colors.Green.Darken2,    // Darker green
							AppbarBackground = Colors.Brown.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Complementary", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Brown.Default,      // Main brown
							Secondary = Colors.Cyan.Default,     // Complementary cyan
							Tertiary = Colors.Cyan.Lighten2,     // Lighter cyan
							AppbarBackground = Colors.Brown.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Brown.Lighten1,     // Slightly lighter brown
							Secondary = Colors.Cyan.Darken2,    // Darker cyan
							Tertiary = Colors.Cyan.Darken3,     // Even darker cyan
							AppbarBackground = Colors.Brown.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Tetradic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Brown.Default,      // Main brown
							Secondary = Colors.Cyan.Default,     // Cyan (complementary to brown)
							Tertiary = Colors.Amber.Default,     // Amber (additional color)
							AppbarBackground = Colors.Brown.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Brown.Lighten1,     // Slightly lighter brown
							Secondary = Colors.Cyan.Darken2,    // Darker cyan
							Tertiary = Colors.Amber.Darken2,    // Darker amber
							AppbarBackground = Colors.Brown.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}
			}
		}, {
			"BlueGray", new Dictionary<string, MudTheme> {
				{
					"Analogous", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.BlueGray.Default, // Main blue gray
							Secondary = Colors.Blue.Default,   // Blue (analogous to blue gray)
							Tertiary = Colors.Teal.Default,    // Teal (analogous to blue gray)
							AppbarBackground = Colors.BlueGray.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.BlueGray.Lighten1, // Slightly lighter blue gray
							Secondary = Colors.Blue.Darken2,   // Darker blue
							Tertiary = Colors.Teal.Darken2,    // Darker teal
							AppbarBackground = Colors.BlueGray.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Monochromatic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.BlueGray.Default,   // Main blue gray
							Secondary = Colors.BlueGray.Lighten2, // Lighter blue gray
							Tertiary = Colors.BlueGray.Darken2,   // Darker blue gray
							AppbarBackground = Colors.BlueGray.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.BlueGray.Lighten1, // Slightly lighter blue gray
							Secondary = Colors.BlueGray.Darken3, // Much darker blue gray
							Tertiary = Colors.BlueGray.Darken1, // Intermediate shade
							AppbarBackground = Colors.BlueGray.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Triadic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.BlueGray.Default, // Main blue gray
							Secondary = Colors.Amber.Default,  // Amber (triadic to blue gray)
							Tertiary = Colors.Green.Default,   // Green (triadic to blue gray)
							AppbarBackground = Colors.BlueGray.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.BlueGray.Lighten1, // Slightly lighter blue gray
							Secondary = Colors.Amber.Darken2,  // Darker amber
							Tertiary = Colors.Green.Darken2,   // Darker green
							AppbarBackground = Colors.BlueGray.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Complementary", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.BlueGray.Default, // Main blue gray
							Secondary = Colors.Orange.Default, // Complementary orange
							Tertiary = Colors.Orange.Lighten2, // Lighter orange
							AppbarBackground = Colors.BlueGray.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.BlueGray.Lighten1, // Slightly lighter blue gray
							Secondary = Colors.Orange.Darken2, // Darker orange
							Tertiary = Colors.Orange.Darken3,  // Even darker orange
							AppbarBackground = Colors.BlueGray.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Tetradic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.BlueGray.Default, // Main blue gray
							Secondary = Colors.Orange.Default, // Orange (complementary to blue gray)
							Tertiary = Colors.Teal.Default,    // Teal (additional color)
							AppbarBackground = Colors.BlueGray.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.BlueGray.Lighten1, // Slightly lighter blue gray
							Secondary = Colors.Orange.Darken2, // Darker orange
							Tertiary = Colors.Teal.Darken2,    // Darker teal
							AppbarBackground = Colors.BlueGray.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}
			}
		}, {
			"Gray", new Dictionary<string, MudTheme> {
				{
					"Analogous", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Gray.Default,       // Main gray
							Secondary = Colors.BlueGray.Default, // Blue gray (analogous to gray)
							Tertiary = Colors.Gray.Lighten2,     // Light gray (analogous to gray)
							AppbarBackground = Colors.Gray.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Gray.Lighten1,      // Slightly lighter gray
							Secondary = Colors.BlueGray.Darken2, // Darker blue gray
							Tertiary = Colors.Gray.Darken2,      // Darker gray
							AppbarBackground = Colors.Gray.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Monochromatic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Gray.Default,       // Main gray
							Secondary = Colors.Gray.Lighten2,    // Lighter gray
							Tertiary = Colors.Gray.Darken2,      // Darker gray
							AppbarBackground = Colors.Gray.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Gray.Lighten1,      // Slightly lighter gray
							Secondary = Colors.Gray.Darken3,    // Much darker gray
							Tertiary = Colors.Gray.Darken1,     // Intermediate shade
							AppbarBackground = Colors.Gray.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Triadic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Gray.Default,       // Main gray
							Secondary = Colors.Blue.Default,     // Blue (triadic to gray)
							Tertiary = Colors.Amber.Default,     // Amber (triadic to gray)
							AppbarBackground = Colors.Gray.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Gray.Lighten1,      // Slightly lighter gray
							Secondary = Colors.Blue.Darken2,    // Darker blue
							Tertiary = Colors.Amber.Darken2,    // Darker amber
							AppbarBackground = Colors.Gray.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Complementary", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Gray.Default,       // Main gray
							Secondary = Colors.Amber.Default,    // Complementary amber
							Tertiary = Colors.Amber.Lighten2,    // Lighter amber
							AppbarBackground = Colors.Gray.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Gray.Lighten1,      // Slightly lighter gray
							Secondary = Colors.Amber.Darken2,   // Darker amber
							Tertiary = Colors.Amber.Darken3,    // Even darker amber
							AppbarBackground = Colors.Gray.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}, {
					"Tetradic", new MudTheme {
						PaletteLight = new PaletteLight {
							Primary = Colors.Gray.Default,       // Main gray
							Secondary = Colors.Amber.Default,    // Amber (complementary to gray)
							Tertiary = Colors.BlueGray.Default,  // Blue gray (additional color)
							AppbarBackground = Colors.Gray.Default,
							AppbarText = Colors.Shades.White
						},
						PaletteDark = new PaletteDark {
							Primary = Colors.Gray.Lighten1,      // Slightly lighter gray
							Secondary = Colors.Amber.Darken2,   // Darker amber
							Tertiary = Colors.BlueGray.Darken2, // Darker blue gray
							AppbarBackground = Colors.Gray.Default,
							AppbarText = Colors.Shades.White
						}
					}
				}
			}
		}
	};
}