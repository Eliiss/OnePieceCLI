module WorldData

open DataTypes // required to use the defined data types for the game 

//---- DEFINING ALL ITEMS ----

//Reverse Mountain items 
let weatheredLogPose = { Id= "Log_pose_west"; Name= "Weathererd Log Pose"; 
Description= "Points West. A rusted Log Pose, its cracked glass fogged with age. 
The needle quivers erratically, as if haunted by the magnetic storms of the Grand Line.
Etched into its brass frame are faded markings of Skypiea and Water 7—whispers of a navigator’s past.";
IsKeyPathItem= true; RiddleId= Some "western_blue_tablet_riddle"}

let marinersAstrolabe = { Id= "astrolabe_east"; Name="Mariner's Astrolabe"; 
Description="Points East. A corroded astrolabe engraved with constellations from the East Blue. 
The handle bears the symbol of Fisher Tiger’s crew, its once-gleaming brass now green with salt. 
When tilted, moonlight catches the etchings of Arlong Park’s coordinates"; 
IsKeyPathItem=true; RiddleId=Some "eastern_blue_tablet_riddle" } 

//West Blue items 
let ethernalPoseThrillerBark = { Id= "thriller_pose_west"; Name= "Ethernal Pose to Thriller Bark"; 
Description= "Points West. A bone-white Eternal Pose, its glass vial filled with murky liquid. 
The needle points unwaveringly to Thriller Bark, and faint screams echo when shaken. 
Carved into the base is Moria’s Jolly Roger, grinning eerily.";
IsKeyPathItem= true; RiddleId= Some "thriller_tablet_riddle"}

let sakuraSeedPouch = { Id= "pouch_east"; Name="Sakura Seed Pouch"; 
Description="Points East. A small velvet pouch filled with cherry blossom seeds, still faintly glowing pink. 
The fabric is singed at the edges, as if rescued from Ohara’s flames. 
A tag reads: “For the country that dreams of snow."; 
IsKeyPathItem=true; RiddleId=Some "kano_tablet_riddle" } 

//East Blue items 
let sanjiSecretSpice = { Id= "secret_spice_west"; Name= "Sanji's Secret Spice"; 
Description= "Points West. A tiny vial of crimson powder tucked inside a soggy cigarette box. The label reads: 
“For emergency kicks.” When opened, the scent of All Blue’s mythical spices mingles with saltwater";
IsKeyPathItem= true; RiddleId= Some "arlong_tablet_riddle"}

let loguetownFerryTicket = { Id= "ticket_east"; Name="Loguetown Ferry Ticket"; 
Description="Points East. A faded parchment ticket stamped with the silhouette of Gol D. Roger’s gallows. 
The edges are singed from Loguetown’s eternal storm, and the ink smells of salt and gunpowder. 
When held to the light, tiny waves ripple across the paper, charting a path to the Red Line’s hidden currents. 
A smudged note reads: “One way to the era of dreams"; 
IsKeyPathItem=true; RiddleId=Some "kano_tablet_riddle" } 

//Thriller Bark items
let brookViolinBow = { Id= "violin_bow_west"; Name= "Brook's Violin Bow"; 
Description= "Points West. A bone-white violin bow, icy to the touch. 
When held, faint echoes of Bink’s Sake drift through the air. The handle is carved with Laboon’s likeness, 
and the hairs glow faintly blue—ghostly remnants of the Rumbar Pirates’ final performance.";
IsKeyPathItem= true; RiddleId= Some "new_world_thriller_riddle"}

let geckoMoriaShadowSnips = { Id= "shadow_east"; Name="Gecko Moria's Shadow Snips"; 
Description="Points East. Rusted shears with jagged blades, still stained with ink-black shadow residue. 
The handles are wrapped in Thriller Bark’s burial shrouds. 
When clinked together, they whisper Oz’s name in a hollow groan."; 
IsKeyPathItem=false; RiddleId=Some "back_west_thriller_riddle" } 

//Kano Country items
let seastoneHandcuffKey = { Id= "handcuff_key_west"; Name= "Seastone Hand cuffKey"; 
Description= "Points West. A hexagonal key forged from Wano’s rarest seastone, cold as the ocean floor. 
The teeth are shaped like Kaido’s scales, and the loop bears Kozuki Oden’s crest. 
When gripped, it weakens even the strongest Devil Fruit user.";
IsKeyPathItem= false; RiddleId= Some "back_west_kano_riddle"}

let ryumaShusuiCloth = { Id= "cloth_east"; Name="Ryuma Shusui's Cloth"; 
Description="Points East. A black cloth embroidered with Wano’s crescent moon. 
It smells of steel and grave soil, and faintly vibrates—as if still clinging to Shusui’s hilt. 
Folded inside is a lock of Ryuma’s hair, silver as moonlight"; 
IsKeyPathItem=true; RiddleId=Some "new_world_kano_riddle" } 

//Arlong Park items 
let completeGrandLineChart = { Id= "grandline_chart_west"; Name= "Complete GrandLine Chart"; 
Description= "Points West. A water-stained scroll labeled with Bellemere’s tangerine grove coordinates. 
The ink shifts like live weather patterns, revealing Laugh Tale’s location to those who solve its riddles. 
Folded into the corners are sketches of Skypiea’s golden bell.";
IsKeyPathItem= true; RiddleId= Some "new_world_arlong_riddle"}

let climaTactPrototype = { Id= "clima_prototype_east"; Name="Clima Tact Prototype"; 
Description="Points East. A clunky brass staff with dials labeled “Mirage Tempo” and “Thunderbolt.” 
Sparks crackle from its joints, smelling of ozone and tangerine peel. 
A sticky note reads: “Usopp’s Version 1.0—handle with care.”"; 
IsKeyPathItem=false; RiddleId=Some "back_east_arlong_riddle" } 

//Logue Town items
let rogerLastWordsEchoShell = { Id= "echo_shell_west"; Name= "Roger Last Words EchoShell"; 
Description= "Points West. A golden Den Den Mushi shell, cold to the touch. 
When held to your ear, it whispers, “My treasure? It’s yours...” in a voice choked with static. 
The edges are stained with dried sake and flecks of confetti from the execution crowd. 
A tiny engraving reads: “To the fool who inherits my will.”";
IsKeyPathItem= true; RiddleId= Some "new_world_logue_riddle"}

let smokerJitteTip = { Id= "smoke_jitte_east"; Name="Smoker Jitte Tip"; 
Description="Points East. A seastone-tipped jitte, still smoldering from Smoker’s cigar burns. 
The shaft is engraved with Marine slogans, but the tip bears a tiny scratch—a memento of Luffy’s first escape. 
It hums with the energy of Loguetown’s storm."; 
IsKeyPathItem=false; RiddleId=Some "back_east_logue_riddle" }

//New World items 
let ancientTranslationKey = { Id= "translation_key_west"; Name= "Ancient Translation Key"; 
Description= "Points West. A cube-shaped key made of Poneglyph fragments, glowing with faint red hieroglyphs. 
When held, visions of Joy Boy’s promise flash like strobe lights. 
The edges are singed, as if plucked from Ohara’s burning Tree of Knowledge.";
IsKeyPathItem= true; RiddleId= Some "end_west_riddle"}

let willOfDInheritance = { Id= "will_west"; Name= "Will Of D. Inheritance"; 
Description= "Points East. A tattered parchment sealed with wax imprinted with the Straw Hat insignia. 
Inside, a single sentence is scrawled in ink made from sea king’s blood: “Inherit the dawn.” 
The paper hums with the rhythm of the Void Century.";
IsKeyPathItem= true; RiddleId= Some "end_east_riddle"}


//---- DEFINING ALL RIDDLES ----
let entranceRiddles =
    Map.ofList [
        ("western_tablet_riddle", { RiddleText = "I point the way but never stay, aging with each island's sway.
        Cross my needle, brave the tide—without me, you’ll lose your guide. What am I?"; Solution = "map"; RewardItemId = weatheredLogPose.Id; CurrentState = NotSolved; 
        SolvedMessage= "The tablet glows brightly! You've solved it."; RewardAppearsMessage = "A Weathered Log Pose materializes on a small pedestal beside the tablet."});
        
        ("eastern_tablet_riddle", { RiddleText = "I am always coming..."; Solution = "tomorrow"; RewardItemId = marinersAstrolabe.Id; CurrentState = NotSolved;
        SolvedMessage= "The tablet glows brightly! You've solved it."; RewardAppearsMessage = "An astrolabe materializes on a small pedestal beside the tablet."})
    ]
