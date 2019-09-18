using System.Resources;

namespace Smelly.Code.Core
{
    public class EvercraftGameDisplay
    {
        private readonly DisplayType _displayType;

        public EvercraftGameDisplay(DisplayType displayType)
        {
            _displayType = displayType;
        }

        public string Render(EvercraftGame game)
        {
            var result = _displayType == DisplayType.Console ? "Characters\n" : "<div>";

            result += _displayType == DisplayType.Web ? "<div data-character>" : "";
            result += _displayType == DisplayType.Web ? $"<div data-name>{game.Chars[0].Name}</div>" : $"{game.Chars[0].Name}:\n"; 
            result += _displayType == DisplayType.Console ? $"\tHit Points: {game.Chars[0].HitPts}\n": $"<div data-hit-points>{game.Chars[0].HitPts}</div>";
            result += _displayType == DisplayType.Web ? $"<div data-armor>{game.Chars[0].Arm}</div>" : $"\tArmor: {game.Chars[0].Arm}\n";
            if (game.Chars[0].Str.HasValue)
            {
                result += _displayType == DisplayType.Console ? $"\tStrength: {game.Chars[0].Str}\n" : $"<div data-strength>{game.Chars[0].Str}</div>";
            }
            else
            {
                result += _displayType == DisplayType.Web ? "<div data-strength>N/A</div>" : "\tStrength: N/A\n";    
            }

            if (game.Chars[0].Dex.HasValue)
            {
                result += _displayType == DisplayType.Console ? $"\tDexterity: {game.Chars[0].Dex}\n" : $"<div data-dexterity>{game.Chars[0].Dex}</div>";
            }
            else
            {
                result += _displayType == DisplayType.Web ? "<div data-dexterity>N/A</div>" : "\tDexterity: N/A\n";
            }

            if (game.Chars[0].Const.HasValue)
            {
                result += _displayType == DisplayType.Console ? $"\tConstitution: {game.Chars[0].Const}\n" : $"<div data-constitution>{game.Chars[0].Const}</div>";
            }
            else
            {
                result += _displayType == DisplayType.Web ? "<div data-constitution>N/A</div>" : "\tConstitution: N/A\n";
            }
            result += _displayType == DisplayType.Web ? "</div>" : "";
            
            result += _displayType == DisplayType.Web ? "<div data-character>" : "";
            result += _displayType == DisplayType.Web ? $"<div data-name>{game.Chars[1].Name}</div>" : $"{game.Chars[1].Name}:\n"; 
            result += _displayType == DisplayType.Console ? $"\tHit Points: {game.Chars[1].HitPts}\n": $"<div data-hit-points>{game.Chars[1].HitPts}</div>";
            result += _displayType == DisplayType.Web ? $"<div data-armor>{game.Chars[1].Arm}</div>" : $"\tArmor: {game.Chars[1].Arm}\n";
            if (game.Chars[1].Str.HasValue)
            {
                result += _displayType == DisplayType.Console ? $"\tStrength: {game.Chars[1].Str}\n" : $"<div data-strength>{game.Chars[1].Str}</div>";
            }
            else
            {
                result += _displayType == DisplayType.Web ? "<div data-strength>N/A</div>" : "\tStrength: N/A\n";    
            }

            if (game.Chars[1].Dex.HasValue)
            {
                result += _displayType == DisplayType.Console ? $"\tDexterity: {game.Chars[1].Dex}\n" : $"<div data-dexterity>{game.Chars[1].Dex}</div>";
            }
            else
            {
                result += _displayType == DisplayType.Web ? "<div data-dexterity>N/A</div>" : "\tDexterity: N/A\n";
            }

            if (game.Chars[1].Const.HasValue)
            {
                result += _displayType == DisplayType.Console ? $"\tConstitution: {game.Chars[1].Const}\n" : $"<div data-constitution>{game.Chars[1].Const}</div>";
            }
            else
            {
                result += _displayType == DisplayType.Web ? "<div data-constitution>N/A</div>" : "\tConstitution: N/A\n";
            }
            result += _displayType == DisplayType.Web ? "</div>" : "";

            result += _displayType == DisplayType.Web ? "</div>" : "";
            return result;
        }
    }
}