using MudBlazor;

namespace MudBlocks.Services {
	public class ThemeService {
		public Dictionary<string, MudTheme> Themes = new Dictionary<string, MudTheme>() {
			{
				"red", new MudTheme() {
					Palette = new PaletteLight() {
						Primary = Colors.Red.Default,
						Secondary = Colors.Cyan.Default,
						Tertiary = Colors.Amber.Default,
						AppbarBackground = Colors.Red.Default,
					}, PaletteDark = new PaletteDark() {
						Primary = Colors.Red.Lighten3,
						Secondary = Colors.Cyan.Lighten3,
						Tertiary = Colors.Amber.Lighten3,
						AppbarBackground = Colors.Red.Default,
					}
				}
			}, {
				"pink", new MudTheme() {
					Palette = new PaletteLight() {
						Primary = Colors.Pink.Default,
						Secondary = Colors.Lime.Default,
						Tertiary = Colors.DeepOrange.Default,
						AppbarBackground = Colors.Pink.Default,
					}, PaletteDark = new PaletteDark() {
						Primary = Colors.Pink.Lighten3,
						Secondary = Colors.Lime.Lighten3,
						Tertiary = Colors.DeepOrange.Lighten3,
						AppbarBackground = Colors.Pink.Default,
					}
				}
			}, {
				"purple", new MudTheme() {
					Palette = new PaletteLight() {
						Primary = Colors.Purple.Default,
						Secondary = Colors.Lime.Default,
						Tertiary = Colors.Orange.Default,
						AppbarBackground = Colors.Purple.Default,
					}, PaletteDark = new PaletteDark() {
						Primary = Colors.Purple.Lighten3,
						Secondary = Colors.Lime.Lighten3,
						Tertiary = Colors.Orange.Lighten3,
						AppbarBackground = Colors.Purple.Default,
					}
				}
			}, {
				"deepPurple", new MudTheme() {
					Palette = new PaletteLight() {
						Primary = Colors.DeepPurple.Default,
						Secondary = Colors.LightGreen.Default,
						Tertiary = Colors.Pink.Default,
						AppbarBackground = Colors.DeepPurple.Default,
					}, PaletteDark = new PaletteDark() {
						Primary = Colors.DeepPurple.Lighten3,
						Secondary = Colors.LightGreen.Lighten3,
						Tertiary = Colors.Pink.Lighten3,
						AppbarBackground = Colors.DeepPurple.Default,
					}
				}
			}, {
				"indigo", new MudTheme() {
					Palette = new PaletteLight() {
						Primary = Colors.Indigo.Default,
						Secondary = Colors.Pink.Default,
						Tertiary = Colors.Yellow.Default,
						AppbarBackground = Colors.Indigo.Default,
					}, PaletteDark = new PaletteDark() {
						Primary = Colors.Indigo.Lighten3,
						Secondary = Colors.Pink.Lighten3,
						Tertiary = Colors.Yellow.Lighten3,
						AppbarBackground = Colors.Indigo.Default,
					}
				}
			}, {
				"blue", new MudTheme() {
					Palette = new PaletteLight() {
						Primary = Colors.Blue.Default,
						Secondary = Colors.Orange.Default,
						Tertiary = Colors.Green.Default,
						AppbarBackground = Colors.Blue.Default,
					}, PaletteDark = new PaletteDark() {
						Primary = Colors.Blue.Lighten3,
						Secondary = Colors.Orange.Lighten3,
						Tertiary = Colors.Green.Lighten3,
						AppbarBackground = Colors.Blue.Default,
					}
				}
			}, {
				"lightBlue", new MudTheme() {
					Palette = new PaletteLight() {
						Primary = Colors.LightBlue.Default,
						Secondary = Colors.Red.Default,
						Tertiary = Colors.Indigo.Default,
						AppbarBackground = Colors.LightBlue.Default,
					}, PaletteDark = new PaletteDark() {
						Primary = Colors.LightBlue.Lighten3,
						Secondary = Colors.Red.Lighten3,
						Tertiary = Colors.Indigo.Lighten3,
						AppbarBackground = Colors.LightBlue.Default,
					}
				}
			}, {
				"cyan", new MudTheme() {
					Palette = new PaletteLight() {
						Primary = Colors.Cyan.Default,
						Secondary = Colors.Purple.Default,
						Tertiary = Colors.Amber.Default,
						AppbarBackground = Colors.Cyan.Default,
					}, PaletteDark = new PaletteDark() {
						Primary = Colors.Cyan.Lighten3,
						Secondary = Colors.Purple.Lighten3,
						Tertiary = Colors.Amber.Lighten3,
						AppbarBackground = Colors.Cyan.Default,
					}
				}
			}, {
				"teal", new MudTheme() {
					Palette = new PaletteLight() {
						Primary = Colors.Teal.Default,
						Secondary = Colors.Pink.Default,
						Tertiary = Colors.Lime.Default,
						AppbarBackground = Colors.Teal.Default,
					}, PaletteDark = new PaletteDark() {
						Primary = Colors.Teal.Lighten3,
						Secondary = Colors.Pink.Lighten3,
						Tertiary = Colors.Lime.Lighten3,
						AppbarBackground = Colors.Teal.Default,
					}
				}
			}, {
				"green", new MudTheme() {
					Palette = new PaletteLight() {
						Primary = Colors.Green.Default,
						Secondary = Colors.Purple.Default,
						Tertiary = Colors.Orange.Default,
						AppbarBackground = Colors.Green.Default,
					}, PaletteDark = new PaletteDark() {
						Primary = Colors.Green.Lighten3,
						Secondary = Colors.Purple.Lighten3,
						Tertiary = Colors.Orange.Lighten3,
						AppbarBackground = Colors.Green.Default,
					}
				}
			}, {
				"lightGreen", new MudTheme() {
					Palette = new PaletteLight() {
						Primary = Colors.LightGreen.Default,
						Secondary = Colors.Pink.Default,
						Tertiary = Colors.Cyan.Default,
						AppbarBackground = Colors.LightGreen.Default,
					}, PaletteDark = new PaletteDark() {
						Primary = Colors.LightGreen.Lighten3,
						Secondary = Colors.Pink.Lighten3,
						Tertiary = Colors.Cyan.Lighten3,
						AppbarBackground = Colors.LightGreen.Default,
					}
				}
			}, {
				"lime", new MudTheme() {
					Palette = new PaletteLight() {
						Primary = Colors.Lime.Default,
						Secondary = Colors.Blue.Default,
						Tertiary = Colors.Purple.Default,
						AppbarBackground = Colors.Lime.Default,
					}, PaletteDark = new PaletteDark() {
						Primary = Colors.Lime.Lighten3,
						Secondary = Colors.Blue.Lighten3,
						Tertiary = Colors.Purple.Lighten3,
						AppbarBackground = Colors.Lime.Default,
					}
				}
			}, {
				"yellow", new MudTheme() {
					Palette = new PaletteLight() {
						Primary = Colors.Yellow.Default,
						Secondary = Colors.Indigo.Default,
						Tertiary = Colors.Cyan.Default,
						AppbarBackground = Colors.Yellow.Default,
					}, PaletteDark = new PaletteDark() {
						Primary = Colors.Yellow.Lighten3,
						Secondary = Colors.Indigo.Lighten3,
						Tertiary = Colors.Cyan.Lighten3,
						AppbarBackground = Colors.Yellow.Default,
					}
				}
			}, {
				"amber", new MudTheme() {
					Palette = new PaletteLight() {
						Primary = Colors.Amber.Default,
						Secondary = Colors.DeepPurple.Default,
						Tertiary = Colors.Green.Default,
						AppbarBackground = Colors.Amber.Default,
					}, PaletteDark = new PaletteDark() {
						Primary = Colors.Amber.Lighten3,
						Secondary = Colors.DeepPurple.Lighten3,
						Tertiary = Colors.Green.Lighten3,
						AppbarBackground = Colors.Amber.Default,
					}
				}
			}, {
				"orange", new MudTheme() {
					Palette = new PaletteLight() {
						Primary = Colors.Orange.Default,
						Secondary = Colors.Cyan.Default,
						Tertiary = Colors.Purple.Default,
						AppbarBackground = Colors.Orange.Default,
					}, PaletteDark = new PaletteDark() {
						Primary = Colors.Orange.Lighten3,
						Secondary = Colors.Cyan.Lighten3,
						Tertiary = Colors.Purple.Lighten3,
						AppbarBackground = Colors.Orange.Default,
					}
				}
			}, {
				"deepOrange", new MudTheme() {
					Palette = new PaletteLight() {
						Primary = Colors.DeepOrange.Default,
						Secondary = Colors.LightBlue.Default,
						Tertiary = Colors.Green.Default,
						AppbarBackground = Colors.DeepOrange.Default,
					}, PaletteDark = new PaletteDark() {
						Primary = Colors.DeepOrange.Lighten3,
						Secondary = Colors.LightBlue.Lighten3,
						Tertiary = Colors.Green.Lighten3,
						AppbarBackground = Colors.DeepOrange.Default,
					}
				}
			}, {
				"brown", new MudTheme() {
					Palette = new PaletteLight() {
						Primary = Colors.Brown.Default,
						Secondary = Colors.Cyan.Default,
						Tertiary = Colors.Amber.Default,
						AppbarBackground = Colors.Brown.Default,
					}, PaletteDark = new PaletteDark() {
						Primary = Colors.Brown.Lighten3,
						Secondary = Colors.Cyan.Lighten3,
						Tertiary = Colors.Amber.Lighten3,
						AppbarBackground = Colors.Brown.Default,
					}
				}
			}, {
				"grey", new MudTheme() {
					Palette = new PaletteLight() {
						Primary = Colors.Grey.Default,
						Secondary = Colors.Red.Default,
						Tertiary = Colors.LightGreen.Default,
						AppbarBackground = Colors.Grey.Default,
					}, PaletteDark = new PaletteDark() {
						Primary = Colors.Grey.Lighten3,
						Secondary = Colors.Red.Lighten3,
						Tertiary = Colors.LightGreen.Lighten3,
						AppbarBackground = Colors.Grey.Default,
					}
				}
			}, {
				"blueGrey", new MudTheme() {
					Palette = new PaletteLight() {
						Primary = Colors.BlueGrey.Default,
						Secondary = Colors.Orange.Default,
						Tertiary = Colors.LightGreen.Default,
						AppbarBackground = Colors.BlueGrey.Default,
					}, PaletteDark = new PaletteDark() {
						Primary = Colors.BlueGrey.Lighten3,
						Secondary = Colors.Orange.Lighten3,
						Tertiary = Colors.LightGreen.Lighten3,
						AppbarBackground = Colors.BlueGrey.Default,
					}
				}
			}
		};
	
		public string Current { get; set; } = "indigo";
	}
}