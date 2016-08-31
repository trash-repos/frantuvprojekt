namespace CustomExtensions
{
    public static class CharExtension
    {
        public static bool IsVowel(this char ch)
        {
            return "aeiouyáéíóúýa̋e̋i̋őűàèìòùỳầềồḕṑǜừằȁȅȉȍȕăĕĭŏŭy̆ắằẳẵặḝȃȇȋȏȗǎěǐǒǔy̌a̧ȩə̧ɛ̧i̧ɨ̧o̧u̧âêîôûŷḙṷẩểổấếốẫễỗậệộäëïöüÿṳḯǘǚṏǟȫǖṻȧėıȯẏǡạẹịọụỵậȩ̇ǡȱảẻỉỏủỷơướứờừởửỡữợựāǣēīōūȳḗṓȭǭąęįǫųy̨åi̊ůḁǻą̊ãẽĩõũỹаэыуояеёюийⱥɇɨøɵꝋʉᵿɏөӫұɨαεηιοωυάέήίόώύὰὲὴὶὸὼὺἀἐἠἰὀὠὐἁἑἡἱὁὡὑᾶῆῖῶῦἆἦἶὦὖἇἧἷὧὗᾳῃῳᾷῇῷᾴῄῴᾲῂῲᾀᾐᾠᾁᾑᾡᾆᾖᾦᾇᾗᾧϊϋΐΰῒῢῗῧἅἕἥἵὅὥὕἄἔἤἴὄὤὔἂἒἢἲὂὢὒἃἓἣἳὃὣὓᾅᾕᾥᾄᾔᾤᾂᾒᾢᾃᾓᾣæɯɪʏʊøɘɤəɛœɜɞʌɔɐɶɑɒιυ"
                     .Contains(""+ch);
        }
    }
    public static class StringExtension
    {
        public static string Vocative(this string slovo)
        {
            var delka = slovo.Length;
            if (delka == 0) { return ""; }

            try
            { //Nastane chyba pokud je slovo o délce 1

                // Výjimka! Změna "ek" na "ku"
                if (slovo.Substring(delka - 2, 2) == "ek")
                {
                    return slovo.Substring(0, delka - 2) + "ku";
                }

                //Supervýjimka! Změna "el" na "le" nebo "eli"
                // ə = samohláska; x = souhláska
                // -əel  → -əeli   (Michael → Michaeli)
                // -xxel → -xxeli  (Marcel → Marceli)
                // -əxel → -əxle   (Karel → Karle)
                if (slovo.Substring(delka - 2, 2) == "el") {
                    if ( slovo[delka - 3].IsVowel() ||
                         !(slovo[delka - 3].IsVowel() || slovo[delka - 4].IsVowel()) )
                    {
                        return slovo + "i";
                    }
                    else
                    {
                        return slovo.Substring(0, delka - 2) + "le";
                    }
                }
            }
            catch { }

            //Pokud nepodléhá výjimce, pokračuj:
            switch (slovo[delka - 1])
            { //rozhoduj podle posl. písmena
                case 'á':
                case 'e':
                case 'é':
                case 'i':
                case 'í':
                case 'o':
                case 'y':
                    //tohle jméno se neskloňuje
                    return slovo;

                case 'g':
                case 'h':
                case 'k':
                case 'q':
                    //k tomuhle jménu se přidává "u"
                    return slovo + "u";

                case 'č':
                case 'j':
                case 'ř':
                case 's':
                case 'š':
                case 'x':
                case 'z':
                    //k tomuhle jménu se přidává "i"
                    return slovo + "i";

                case 'a':
                case 'u':
                    //tady se posl. písmeno mění na "o"
                    return slovo.Substring(0, delka-1) + "o";

                case 'c':
                    //změna "c" na "če"
                    return slovo.Substring(0, delka-1) + "če";

                case 'ď':
                    //změna "ď" na "di"
                    return slovo.Substring(0, delka-1) + "di";

                case 'ň':
                    //změna "ň" na "ni"
                    return slovo.Substring(0, delka-1) + "ni";

                case 'ť':
                    //změna "ť" na "ti"
                    return slovo.Substring(0, delka-1) + "ti";

                case 'r':
                    //změna "r" na "ře"
                    return slovo.Substring(0, delka-1) + "ře";

                default:
                    //všechno ostatní končí na "e"
                    return slovo + "e";

            }
        }
    }
}