using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RandomMCBanner
{
    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }

        //{
        //    "white", // 0
        //    "orange",
        //    "magenta",
        //    "light_blue",
        //    "yellow", // 4
        //    "lime",
        //    "pink",
        //    "gray",
        //    "light_gray", // 8
        //    "cyan",
        //    "purple",
        //    "blue",
        //    "brown", // 12
        //    "green",
        //    "red",
        //    "black"
        //};
        readonly string[] colours = "white,orange,magenta,light_blue,yellow,lime,pink,gray,light_gray,cyan,purple,blue,brown,green,red,black".Split(',');
        readonly string[] patterns = "b,bs,ts,ls,rs,cs,ms,drs,dls,ss,cr,sc,ld,rud,lud,rd,vh,vhr,hh,hhb,bl,br,tl,tr,bt,tt,bts,tts,mc,mr,bo,cbo,bri,gra,gru,cre,sku,flo,moj,glb,pig".Split(',');
        
		
		// Basic syntax:
		// https://www.digminecraft.com/generators/give_banner_1_16.php
		
		// Colour list:
		// https://www.digminecraft.com/lists/pattern_color_list_pc.php
		
		// Pattern list:
		// https://minecraft.fandom.com/wiki/Banner/Patterns
		
		// Banner reference:
		// https://minecraft.tools/en/img/outils/bannersx4.png

        Random r = new Random();

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int depth = (int)nudPatternDepth.Value;

            var sb = new StringBuilder();

            sb.Append("/give @p ");
            sb.Append($"{colours[r.Next(0, 16)]}_banner{{");

            var displayName = txbDisplayName.Text.Trim();
            var lore = txbLore.Text.Trim();
            if (displayName.Length > 0 || lore.Length > 0)
                sb.Append($"display: {{ Name: \"\\\"{ displayName }\\\"\", Lore: [\"\\\"{ lore }\\\"\"]}}, ");

            sb.Append("BlockEntityTag: { Patterns: [ ");

            var patternList = new List<string>();
            string pattern;
            int colour;
            for (var a = 0; a < depth; a++)
            {
                pattern = patterns[r.Next(0, patterns.Length)];
                colour = r.Next(0, 16);
                patternList.Add($"{{ Pattern: \"{pattern}\", Color: {colour} }}");
            }
            sb.Append(string.Join(", ", patternList));

			// the amount of items
            sb.Append(" ]}} 1");

            txbOutput.Text = sb.ToString();
        }
    }
}
