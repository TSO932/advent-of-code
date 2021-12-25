namespace AoC2015

module Day10Part2 =

    let lookAndSay(look:list<string>) =

        let elementMap = ["H", ["H"]; "22", ["H"]; 
            "He", ["Hf";"Pa";"H";"Ca";"Li"]; "13112221133211322112211213322112", ["Hf";"Pa";"H";"Ca";"Li"]; 
            "Li", ["He"]; "312211322212221121123222112", ["He"]; 
            "Be", ["Ge";"Ca";"Li"]; "111312211312113221133211322112211213322112", ["Ge";"Ca";"Li"]; 
            "B", ["Be"]; "1321132122211322212221121123222112", ["Be"]; 
            "C", ["B"]; "3113112211322112211213322112", ["B"]; 
            "N", ["C"]; "111312212221121123222112", ["C"]; 
            "O", ["N"]; "132112211213322112", ["N"]; 
            "F", ["O"]; "31121123222112", ["O"]; 
            "Ne", ["F"]; "111213322112", ["F"]; 
            "Na", ["Ne"]; "123222112", ["Ne"]; 
            "Mg", ["Pm";"Na"]; "3113322112", ["Pm";"Na"]; 
            "Al", ["Mg"]; "1113122112", ["Mg"]; 
            "Si", ["Al"]; "1322112", ["Al"]; 
            "P", ["Ho";"Si"]; "311311222112", ["Ho";"Si"]; 
            "S", ["P"]; "1113122112", ["P"]; 
            "Cl", ["S"]; "132112", ["S"]; 
            "Ar", ["Cl"]; "3112", ["Cl"]; 
            "K", ["Ar"]; "1112", ["Ar"]; 
            "Ca", ["K"]; "12", ["K"]; 
            "Sc", ["Ho";"Pa";"H";"Ca";"Co"]; "3113112221133112", ["Ho";"Pa";"H";"Ca";"Co"]; 
            "Ti", ["Sc"]; "11131221131112", ["Sc"]; 
            "V", ["Ti"]; "13211312", ["Ti"]; 
            "Cr", ["V"]; "31132", ["V"]; 
            "Mn", ["Cr";"Si"]; "111311222112", ["Cr";"Si"]; 
            "Fe", ["Mn"]; "13122112", ["Mn"]; 
            "Co", ["Fe"]; "32112", ["Fe"]; 
            "Ni", ["Zn";"Co"]; "11133112", ["Zn";"Co"]; 
            "Cu", ["Ni"]; "131112", ["Ni"]; 
            "Zn", ["Cu"]; "312", ["Cu"]; 
            "Ga", ["Eu";"Ca";"Ac";"H";"Ca";"Zn"]; "13221133122211332", ["Eu";"Ca";"Ac";"H";"Ca";"Zn"]; 
            "Ge", ["Ho";"Ga"]; "31131122211311122113222", ["Ho";"Ga"]; 
            "As", ["Ge";"Na"]; "11131221131211322113322112", ["Ge";"Na"]; 
            "Se", ["As"]; "13211321222113222112", ["As"]; 
            "Br", ["Se"]; "3113112211322112", ["Se"]; 
            "Kr", ["Br"]; "11131221222112", ["Br"]; 
            "Rb", ["Kr"]; "1321122112", ["Kr"]; 
            "Sr", ["Rb"]; "3112112", ["Rb"]; 
            "Y", ["Sr";"U"]; "1112133", ["Sr";"U"]; 
            "Zr", ["Y";"H";"Ca";"Tc"]; "12322211331222113112211", ["Y";"H";"Ca";"Tc"]; 
            "Nb", ["Er";"Zr"]; "1113122113322113111221131221", ["Er";"Zr"]; 
            "Mo", ["Nb"]; "13211322211312113211", ["Nb"]; 
            "Tc", ["Mo"]; "311322113212221", ["Mo"]; 
            "Ru", ["Eu";"Ca";"Tc"]; "132211331222113112211", ["Eu";"Ca";"Tc"]; 
            "Rh", ["Ho";"Ru"]; "311311222113111221131221", ["Ho";"Ru"]; 
            "Pd", ["Rh"]; "111312211312113211", ["Rh"]; 
            "Ag", ["Pd"]; "132113212221", ["Pd"]; 
            "Cd", ["Ag"]; "3113112211", ["Ag"]; 
            "In", ["Cd"]; "11131221", ["Cd"]; 
            "Sn", ["In"]; "13211", ["In"]; 
            "Sb", ["Pm";"Sn"]; "3112221", ["Pm";"Sn"]; 
            "Te", ["Eu";"Ca";"Sb"]; "1322113312211", ["Eu";"Ca";"Sb"]; 
            "I", ["Ho";"Te"]; "311311222113111221", ["Ho";"Te"]; 
            "Xe", ["I"]; "11131221131211", ["I"]; 
            "Cs", ["Xe"]; "13211321", ["Xe"]; 
            "Ba", ["Cs"]; "311311", ["Cs"]; 
            "La", ["Ba"]; "11131", ["Ba"]; 
            "Ce", ["La";"H";"Ca";"Co"]; "1321133112", ["La";"H";"Ca";"Co"]; 
            "Pr", ["Ce"]; "31131112", ["Ce"]; 
            "Nd", ["Pr"]; "111312", ["Pr"]; 
            "Pm", ["Nd"]; "132", ["Nd"]; 
            "Sm", ["Pm";"Ca";"Zn"]; "311332", ["Pm";"Ca";"Zn"]; 
            "Eu", ["Sm"]; "1113222", ["Sm"]; 
            "Gd", ["Eu";"Ca";"Co"]; "13221133112", ["Eu";"Ca";"Co"]; 
            "Tb", ["Ho";"Gd"]; "3113112221131112", ["Ho";"Gd"]; 
            "Dy", ["Tb"]; "111312211312", ["Tb"]; 
            "Ho", ["Dy"]; "1321132", ["Dy"]; 
            "Er", ["Ho";"Pm"]; "311311222", ["Ho";"Pm"]; 
            "Tm", ["Er";"Ca";"Co"]; "11131221133112", ["Er";"Ca";"Co"]; 
            "Yb", ["Tm"]; "1321131112", ["Tm"]; 
            "Lu", ["Yb"]; "311312", ["Yb"]; 
            "Hf", ["Lu"]; "11132", ["Lu"]; 
            "Ta", ["Hf";"Pa";"H";"Ca";"W"]; "13112221133211322112211213322113", ["Hf";"Pa";"H";"Ca";"W"]; 
            "W", ["Ta"]; "312211322212221121123222113", ["Ta"]; 
            "Re", ["Ge";"Ca";"W"]; "111312211312113221133211322112211213322113", ["Ge";"Ca";"W"]; 
            "Os", ["Re"]; "1321132122211322212221121123222113", ["Re"]; 
            "Ir", ["Os"]; "3113112211322112211213322113", ["Os"]; 
            "Pt", ["Ir"]; "111312212221121123222113", ["Ir"]; 
            "Au", ["Pt"]; "132112211213322113", ["Pt"]; 
            "Hg", ["Au"]; "31121123222113", ["Au"]; 
            "Tl", ["Hg"]; "111213322113", ["Hg"]; 
            "Pb", ["Tl"]; "123222113", ["Tl"]; 
            "Bi", ["Pm";"Pb"]; "3113322113", ["Pm";"Pb"]; 
            "Po", ["Bi"]; "1113222113", ["Bi"]; 
            "At", ["Po"]; "1322113", ["Po"]; 
            "Rn", ["Ho";"At"]; "311311222113", ["Ho";"At"]; 
            "Fr", ["Rn"]; "1113122113", ["Rn"]; 
            "Ra", ["Fr"]; "132113", ["Fr"]; 
            "Ac", ["Ra"]; "3113", ["Ra"]; 
            "Th", ["Ac"]; "1113", ["Ac"]; 
            "Pa", ["Th"]; "13", ["Th"]; 
            "U", ["Pa"]; "3", ["Pa"]] |> Map.ofList

        look |> List.collect (fun x -> elementMap.[x])

    let lookAndSayRepeat(repeats:int, look:string) =
    
        let lengthMap = ["H", 2;
                        "He", 32;
                        "Li", 27;
                        "Be", 42;
                        "B", 34;
                        "C", 28;
                        "N", 24;
                        "O", 18;
                        "F", 14;
                        "Ne", 12;
                        "Na", 9;
                        "Mg", 10;
                        "Al", 10;
                        "Si", 7;
                        "P", 12;
                        "S", 10;
                        "Cl", 6;
                        "Ar", 4;
                        "K", 4;
                        "Ca", 2;
                        "Sc", 16;
                        "Ti", 14;
                        "V", 8;
                        "Cr", 5;
                        "Mn", 12;
                        "Fe", 8;
                        "Co", 5;
                        "Ni", 8;
                        "Cu", 6;
                        "Zn", 3;
                        "Ga", 17;
                        "Ge", 23;
                        "As", 26;
                        "Se", 20;
                        "Br", 16;
                        "Kr", 14;
                        "Rb", 10;
                        "Sr", 7;
                        "Y", 7;
                        "Zr", 23;
                        "Nb", 28;
                        "Mo", 20;
                        "Tc", 15;
                        "Ru", 21;
                        "Rh", 24;
                        "Pd", 18;
                        "Ag", 12;
                        "Cd", 10;
                        "In", 8;
                        "Sn", 5;
                        "Sb", 7;
                        "Te", 13;
                        "I", 18;
                        "Xe", 14;
                        "Cs", 8;
                        "Ba", 6;
                        "La", 5;
                        "Ce", 10;
                        "Pr", 8;
                        "Nd", 6;
                        "Pm", 3;
                        "Sm", 6;
                        "Eu", 7;
                        "Gd", 11;
                        "Tb", 16;
                        "Dy", 12;
                        "Ho", 7;
                        "Er", 9;
                        "Tm", 14;
                        "Yb", 10;
                        "Lu", 6;
                        "Hf", 5;
                        "Ta", 32;
                        "W", 27;
                        "Re", 42;
                        "Os", 34;
                        "Ir", 28;
                        "Pt", 24;
                        "Au", 18;
                        "Hg", 14;
                        "Tl", 12;
                        "Pb", 9;
                        "Bi", 10;
                        "Po", 10;
                        "At", 7;
                        "Rn", 12;
                        "Fr", 10;
                        "Ra", 6;
                        "Ac", 4;
                        "Th", 4;
                        "Pa", 2;
                        "U", 1] |> Map.ofList

        let mutable say = [look]

        for _ in 1 .. repeats do
            say <- lookAndSay(say)

        List.sumBy (fun x -> lengthMap.[x]) say