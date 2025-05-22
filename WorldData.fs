module WorldData

open DataTypes // required to use the defined data types for the game 

//---- DEFINING ALL ITEMS ----

//Reverse Mountain items 
let weatheredLogPose = { Id= "log_pose_west"; Name= "Weathererd Log Pose"; 
Description= """
Points West. A rusted Log Pose, its cracked glass fogged with age. 
The needle quivers erratically, as if haunted by the magnetic storms of the Grand Line.
Etched into its brass frame are faded markings of Skypiea and Water 7—whispers of a navigator’s past.
""";
IsKeyPathItem= true; RiddleId= Some "western_blue_tablet_riddle"; OriginLocation = Some "entrance"}

let marinersAstrolabe = { Id= "astrolabe_east"; Name="Mariner's Astrolabe"; 
Description="""
Points East. A corroded astrolabe engraved with constellations from the East Blue. 
The handle bears the symbol of Fisher Tiger’s crew, its once-gleaming brass now green with salt. 
When tilted, moonlight catches the etchings of Arlong Park’s coordinates
"""; 
IsKeyPathItem=true; RiddleId=Some "eastern_blue_tablet_riddle"; OriginLocation = Some "entrance"} 

//West Blue items 
let ethernalPoseThrillerBark = { Id= "thriller_pose_west"; Name= "Ethernal Pose to Thriller Bark"; 
Description= """
Points West. A bone-white Eternal Pose, its glass vial filled with murky liquid. 
The needle points unwaveringly to Thriller Bark, and faint screams echo when shaken. 
Carved into the base is Moria’s Jolly Roger, grinning eerily.
""";
IsKeyPathItem= true; RiddleId= Some "thriller_tablet_riddle" ; OriginLocation = Some "west_blue"}

let sakuraSeedPouch = { Id= "pouch_east"; Name="Sakura Seed Pouch"; 
Description="""
Points East. A small velvet pouch filled with cherry blossom seeds, still faintly glowing pink. 
The fabric is singed at the edges, as if rescued from Ohara’s flames. 
A tag reads: “For the country that dreams of snow.
"""; 
IsKeyPathItem=true; RiddleId=Some "kano_tablet_riddle" ; OriginLocation = Some "west_blue"} 

//East Blue items 
let sanjiSecretSpice = { Id= "secret_spice_west"; Name= "Sanji's Secret Spice"; 
Description= """
Points West. A tiny vial of crimson powder tucked inside a soggy cigarette box. The label reads: 
“For emergency kicks.” When opened, the scent of All Blue’s mythical spices mingles with saltwater
""";
IsKeyPathItem= true; RiddleId= Some "arlong_tablet_riddle" ; OriginLocation = Some "east_blue"}

let loguetownFerryTicket = { Id= "ticket_east"; Name="Loguetown Ferry Ticket"; 
Description="""
Points East. A faded parchment ticket stamped with the silhouette of Gol D. Roger’s gallows. 
The edges are singed from Loguetown’s eternal storm, and the ink smells of salt and gunpowder. 
When held to the light, tiny waves ripple across the paper, charting a path to the Red Line’s hidden currents. 
A smudged note reads: “One way to the era of dreams
"""; 
IsKeyPathItem=true; RiddleId=Some "logue_town_riddle" ; OriginLocation = Some "east_blue"} 

//Thriller Bark items
let brookViolinBow = { Id= "violin_bow_east"; Name= "Brook's Violin Bow"; 
Description= """
Points East. A bone-white violin bow, icy to the touch. 
When held, faint echoes of Bink’s Sake drift through the air. The handle is carved with Laboon’s likeness, 
and the hairs glow faintly blue—ghostly remnants of the Rumbar Pirates’ final performance.
""";
IsKeyPathItem= true; RiddleId= Some "new_world_thriller_riddle" ; OriginLocation = Some "thriller_bark"}

let geckoMoriaShadowSnips = { Id= "shadow_west"; Name="Gecko Moria's Shadow Snips"; 
Description= """
Points West. Rusted shears with jagged blades, still stained with ink-black shadow residue. 
The handles are wrapped in Thriller Bark’s burial shrouds. 
When clinked together, they whisper Oz’s name in a hollow groan.
"""; 
IsKeyPathItem=true; RiddleId=Some "back_west_thriller_riddle" ; OriginLocation = Some "thriller_bark" } 

//Kano Country items
let seastoneHandcuffKey = { Id= "handcuff_key_west"; Name= "Seastone Hand cuffKey"; 
Description= """
Points West. A hexagonal key forged from Wano’s rarest seastone, cold as the ocean floor. 
The teeth are shaped like Kaido’s scales, and the loop bears Kozuki Oden’s crest. 
When gripped, it weakens even the strongest Devil Fruit user.
""";
IsKeyPathItem= true; RiddleId= Some "back_west_kano_riddle" ; OriginLocation = Some "kano_country"}

let ryumaShusuiCloth = { Id= "cloth_east"; Name="Ryuma Shusui's Cloth"; 
Description= """
Points East. A black cloth embroidered with Wano’s crescent moon. 
It smells of steel and grave soil, and faintly vibrates—as if still clinging to Shusui’s hilt. 
Folded inside is a lock of Ryuma’s hair, silver as moonlight
"""; 
IsKeyPathItem=true; RiddleId=Some "new_world_kano_riddle" ; OriginLocation = Some "kano_country"} 

//Arlong Park items 
let completeGrandLineChart = { Id= "grandline_chart_west"; Name= "Complete GrandLine Chart"; 
Description= """
Points West. A water-stained scroll labeled with Bellemere’s tangerine grove coordinates. 
The ink shifts like live weather patterns, revealing Laugh Tale’s location to those who solve its riddles. 
Folded into the corners are sketches of Skypiea’s golden bell.
""";
IsKeyPathItem= true; RiddleId= Some "new_world_arlong_riddle" ; OriginLocation = Some "arlong_park"}

let climaTactPrototype = { Id= "clima_prototype_east"; Name="Clima Tact Prototype"; 
Description="""
Points East. A clunky brass staff with dials labeled “Mirage Tempo” and “Thunderbolt.” 
Sparks crackle from its joints, smelling of ozone and tangerine peel. 
A sticky note reads: “Usopp’s Version 1.0—handle with care.”
"""; 
IsKeyPathItem=true; RiddleId=Some "back_east_arlong_riddle" ; OriginLocation = Some "arlong_park" } 

//Logue Town items
let rogerLastWordsEchoShell = { Id= "echo_shell_west"; Name= "Roger Last Words EchoShell"; 
Description= """
Points West. A golden Den Den Mushi shell, cold to the touch. 
When held to your ear, it whispers, “My treasure? It’s yours...” in a voice choked with static. 
The edges are stained with dried sake and flecks of confetti from the execution crowd. 
A tiny engraving reads: “To the fool who inherits my will.”
""";
IsKeyPathItem= true; RiddleId= Some "new_world_logue_riddle" ; OriginLocation = Some "logue_town"}

let smokerJitteTip = { Id= "smoke_jitte_east"; Name="Smoker Jitte Tip"; 
Description="""
Points East. A seastone-tipped jitte, still smoldering from Smoker’s cigar burns. 
The shaft is engraved with Marine slogans, but the tip bears a tiny scratch—a memento of Luffy’s first escape. 
It hums with the energy of Loguetown’s storm.
"""; 
IsKeyPathItem=true; RiddleId=Some "back_east_logue_riddle" ; OriginLocation = Some "logue_town"}

//New World items 
let ancientTranslationKey = { Id= "translation_key_west"; Name= "Ancient Translation Key"; 
Description= """
Points West. A cube-shaped key made of Poneglyph fragments, glowing with faint red hieroglyphs. 
When held, visions of Joy Boy’s promise flash like strobe lights. 
The edges are singed, as if plucked from Ohara’s burning Tree of Knowledge.
""";
IsKeyPathItem= true; RiddleId= Some "end_west_riddle" ; OriginLocation = Some "new_world"}

let willOfDInheritance = { Id= "will_west"; Name= "Will Of D. Inheritance"; 
Description= """
Points East. A tattered parchment sealed with wax imprinted with the Straw Hat insignia. 
Inside, a single sentence is scrawled in ink made from sea king’s blood: “Inherit the dawn.” 
The paper hums with the rhythm of the Void Century.
""";
IsKeyPathItem= true; RiddleId= Some "end_east_riddle" ; OriginLocation = Some "new_world"}

let allItemsList =
    [ weatheredLogPose; marinersAstrolabe; sakuraSeedPouch; ethernalPoseThrillerBark; sanjiSecretSpice; 
    loguetownFerryTicket; brookViolinBow; geckoMoriaShadowSnips; seastoneHandcuffKey; ryumaShusuiCloth; 
    completeGrandLineChart; climaTactPrototype; rogerLastWordsEchoShell; smokerJitteTip; ancientTranslationKey; 
    willOfDInheritance ]

let allItemsMap : Map<string, Item> =
    allItemsList
    |> List.map (fun item -> (item.Id, item))
    |> Map.ofList


//---- DEFINING ALL RIDDLES ----
let entranceRiddles =
    Map.ofList [
        ("western_tablet_riddle", { RiddleText = "I point the way but never stay, aging with each island's sway.\nCross my needle, brave the tide—without me, you’ll lose your guide. What am I?"; Solution = "compass"; 
        RewardItemId = weatheredLogPose.Id; CurrentState = NotSolved; 
        SolvedMessage= "The tablet glows brightly! You've solved it."; RewardAppearsMessage = "A Weathered Log Pose materializes on a small pedestal beside the tablet."});
        
        ("eastern_tablet_riddle", { RiddleText = "I chart the stars to guide your path,but alone I’m just a metal staff.
        Lift me high, and you might see the shadow of the Sun Pirate’s sea. What am I?"; Solution = "astrolabe"; RewardItemId = marinersAstrolabe.Id; CurrentState = NotSolved;
        SolvedMessage= "The tablet glows brightly! You've solved it."; RewardAppearsMessage = "An astrolabe materializes on a small pedestal beside the tablet."})
    ]

let westBlueRiddles =
    Map.ofList [
        ("kano_tablet_riddle", { RiddleText = "Born from snow that never melts, my tears are pink and I bloom where a doctor’s legacy dwells.\nScatter my gift to heal the earth—but only after proving your worth."; 
        Solution = "sakura petals"; RewardItemId = sakuraSeedPouch.Id; CurrentState = NotSolved; 
        SolvedMessage= "Cherry blossoms begin to fall around you, despite there being no trees nearby. \nThe scent of Dr. Hiriluk's medicine fills the air.";
        RewardAppearsMessage = "A small velvet pouch materializes, glowing with a soft pink light. \nInside, you can see the Sakura Seed Pouch containing seeds of hope."});
        
        ("thriller_tablet_riddle", { RiddleText = "A ship that never sails, where moonlight pierces ghostly veils. \nTo claim my prize, you must first see the shadow of a king’s decree."; 
        Solution = "Thriller Bark"; RewardItemId = ethernalPoseThrillerBark.Id; CurrentState = NotSolved;
        SolvedMessage= "A haunting melody plays as the fog around the tablet dissipates. \nGecko Moria's laughter echoes briefly before fading away.";
        RewardAppearsMessage = "The shadows twist and coalesce, forming an Eternal Pose to Thriller Bark that hovers ominously before settling on the ground."})
    ]

let eastBlueRiddles =
    Map.ofList [
        ("arlong_tablet_riddle", { RiddleText = "I’m not for eating, though I’m flavored with fire. \nI can be hot, I can be sweet, I can make a bland dish a treat. Used by chefs with flair and might, what am I that makes food bright?"; 
        Solution = "spice"; RewardItemId = sanjiSecretSpice.Id; CurrentState = NotSolved; 
        SolvedMessage= "Water droplets rise from the ground, forming Nami's navigation symbol before splashing back down. \nThe tablet's markings rearrange into a map of the East Blue.";
        RewardAppearsMessage = "Steam rises from the ground, bringing with it the tantalizing aroma of Sanji's cooking. \nA small vial of crimson powder appears, labeled 'Secret Spice.'"});
        
        ("logue_town_riddle", { RiddleText = "I’m not gold, but I’ll take you far —to where the King’s last words are. \nI'm not a boat, but I'll let you ride across the sea. \nSpeak the name of the Straw Hat's heart. What am I?"; 
        Solution = "ticket"; RewardItemId = loguetownFerryTicket.Id; CurrentState = NotSolved;
        SolvedMessage= "Lightning crackles overhead as thunder booms—just like the weather at Roger's execution. The tablet's surface ripples like the sea during a storm.";
        RewardAppearsMessage = "A gust of wind blows through, carrying what looks like confetti from a distant celebration. \nAs it settles, a ferry ticket materializes, bearing the mark of Loguetown."})
    ]

let thrillerBarkRiddles =
    Map.ofList [
        ("new_world_thriller_riddle", { RiddleText = "I play the songs of souls long gone. I bring joy or sorrow from afar. \nMy voice can soothe a restless soul, or make the bravest lose control.\nTo wield my music,you must first see—the tears of a whale in the Florian Triangle Sea. What am I?"; 
        Solution = "violin"; RewardItemId = brookViolinBow.Id; CurrentState = NotSolved; 
        SolvedMessage= "A haunting violin melody plays from nowhere, and for a brief moment, you see the silhouette of a skeletal musician bowing gracefully.";
        RewardAppearsMessage = "Moonlight catches on something white and delicate—Brook's Violin Bow appears, \nresting on an ethereal music stand that fades leaving only the bow behind"});
        
        ("back_west_thriller_riddle", { RiddleText = " I steal the dark that follows light, and stitch the night to fuel your might. \nBut use me wrong, and you’ll soon know. I follow you all the time and copy your every move, but you can’t touch me or catch me. What am I?"; 
        Solution = "shadow"; RewardItemId = geckoMoriaShadowSnips.Id; CurrentState = NotSolved;
        SolvedMessage= "Your shadow stretches unnaturally, then detaches slightly from your feet before snapping back. \nGecko Moria's signature 'Kishishishi' laugh echoes faintly";
        RewardAppearsMessage = "The darkness thickens in your hands, solidifying into a pair of rusted shears—Gecko Moria's Shadow Snips, \nstill stained with shadow residue."})
    ]

let kanoRiddles =
    Map.ofList [
        ("back_west_kano_riddle", { RiddleText = "What is always in front of you but can’t be seen, especially when you are in chains?"; 
        Solution = "future"; RewardItemId = seastoneHandcuffKey.Id; CurrentState = NotSolved; 
        SolvedMessage= "You feel momentarily weakened, as if touching seastone. The tablet's surface ripples with the imprint of handcuffs breaking apart.";
        RewardAppearsMessage = "Something cold and metallic materializes — a hexagonal Seastone Handcuff Key that seems to drain energy from the very air around it."});
        
        ("new_world_kano_riddle", { RiddleText = " I have no life, but I can die. I have no sword, but I can make a samurai cry. What am I?"; 
        Solution = "honor"; RewardItemId = ryumaShusuiCloth.Id; CurrentState = NotSolved;
        SolvedMessage= "Cherry blossoms swirl around you as the tablet reveals an ancient Wano symbol. You hear the distant clash of legendary swords.";
        RewardAppearsMessage = "A piece of cloth floats down from above, embroidered with Wano's crescent moon—Ryuma's Shusui Cloth, \ncarrying with it the scent of steel and honor."})
    ]

let arlongRiddles =
    Map.ofList [
        ("new_world_arlong_riddle", { RiddleText = "I encompass the world but am no bigger than your hand. Sailors trust me more than the stars or land. What am I"; 
        Solution = "map"; RewardItemId = completeGrandLineChart.Id; CurrentState = NotSolved; 
        SolvedMessage= "The scent of tangerines fills the air as ink draws itself across the tablet, forming an intricate map that briefly shows the entirety of the Grand Line.";
        RewardAppearsMessage = "Water swirls upward, forming a scroll that solidifies into Nami's Complete Grand Line Chart, its edges still dripping with seawater."});
        
        ("back_east_arlong_riddle", { RiddleText = " What can fly without wings, cry without eyes, and when it is happy, it makes rainbows in the skies?"; 
        Solution = "cloud"; RewardItemId = climaTactPrototype.Id; CurrentState = NotSolved;
        SolvedMessage= "A miniature storm cloud forms above the tablet, releasing a tiny thunderbolt that dances across the surface. You hear Nami's triumphant laugh.";
        RewardAppearsMessage = "Gears and dials click together, assembling themselves into Usopp's Clima Tact Prototype, sparking with untamed weather energy."})
    ]

let logueRiddles =
    Map.ofList [
        ("new_world_logue_riddle", { RiddleText = "I am the beginning of everything, the end of everywhere. I'm the beginning of eternity, the end of time and space. \nWhat am I?"; 
        Solution = "e"; RewardItemId = rogerLastWordsEchoShell.Id; CurrentState = NotSolved; 
        SolvedMessage= "Rain begins to fall as the tablet resonates with the voice of the Pirate King: 'My treasure? It's yours if you can find it!' 
        The words fade into the sound of cheering crowds.";
        RewardAppearsMessage = "A golden shell materializes, still echoing with the final words of Gol D. Roger the Echo Shell that captured the moment that started the Great Pirate Era."});
        
        ("back_east_logue_riddle", { RiddleText = "I hunt the free with justice’s glare, a marine’s pride, a pirate’s nightmare. \nTo claim my edge, you must confess—the name of the man who said ‘Yes!"; 
        Solution = "Gol D. Roger"; RewardItemId = smokerJitteTip.Id; CurrentState = NotSolved;
        SolvedMessage= "Smoke curls from the tablet, forming Marine insignias that dissolve into the air. \nYou catch the scent of cigar smoke and sea breeze.";
        RewardAppearsMessage = "Metal glints as Smoker's Jitte Tip appears, the seastone still radiating its Devil Fruit."})
    ]

let newRiddles =
    Map.ofList [
        ("end_west_riddle", { RiddleText = "I speak without a mouth and hear without ears. I have no body, but I come alive with wind. \nWhat am I?"; 
        Solution = "echo"; RewardItemId = ancientTranslationKey.Id; CurrentState = NotSolved; 
        SolvedMessage= "Ancient symbols flash across the tablet's surface, each one representing a piece of the Void Century. The truth of history briefly illuminates before your eyes.";
        RewardAppearsMessage = "Fragments of red stone assemble themselves into the Ancient Translation Key, humming with the forbidden knowledge of the Poneglyphs."});
        
        ("end_east_riddle", { RiddleText = "What is broken every time it's spoken?"; 
        Solution = "silence"; RewardItemId = willOfDInheritance.Id; CurrentState = NotSolved;
        SolvedMessage= "The tablet reveals the hidden meaning of D., showing faces of all who carried the initial throughout history. \nTheir smiles merge into a single determined grin";
        RewardAppearsMessage = "Wax melts and reforms, sealing a parchment that materializes in the air—the Will of D. Inheritance, marked with the Straw Hat insignia."})
    ]

//---- DEFINING ALL LOCATIONS ----

let entrance =
    { Id = "entrance"
      Name = "Reverse Mountain Foothills"
      Description = """
      You stand at the base of Reverse Mountain, where the four seas collide. 
      The colossal stone arch looms above, carved with ancient glyphs worn smooth by centuries of saltwater. 
      The roar of the ascending currents drowns out all sound, a chaotic orchestra of waves crashing against the Red Line. 
      To the north, icy winds carry the whispers of forgotten pirate crews; to the west, the salty tang of West Blue’s storms stings your lips. 
      A lone albatross circles overhead, its cry echoing the question: “Are you ready to brave the Grand Line?
      """
      UnavailableItems = Map.ofList [ (weatheredLogPose.Id, weatheredLogPose); (marinersAstrolabe.Id, marinersAstrolabe) ] // Start as unavailable
      AvailableItems = Map.empty
      NextLocation = Map.ofList [ (West, "west_blue"); (East, "east_blue") ]
      Riddles = entranceRiddles 
      NextLocationUnlockRequirements = Map.ofList [ (West, {RequiredItemId = Some weatheredLogPose.Id}); (East, {RequiredItemId = Some marinersAstrolabe.Id}) ]
    }

let west_blue =
    { Id = "west_blue"
      Name = "Ohara Library Ruins"
      Description = """
      The skeletal remains of Ohara’s Library rise before you, their blackened stone pillars clawing at the sky like the fingers of the World Government’s wrath. 
      Charred pages flutter in the breeze, fragments of a history the Marines tried to erase. 
      Beneath your boots, the ground is littered with shattered Poneglyph replicas, their engravings blurred by ash. 
      A faint glow pulses from the base of the Tree of Knowledge’s stump —a ghostly flame that never dies. 
      The air smells of burnt parchment and regret.
      """
      UnavailableItems = Map.ofList [ (sakuraSeedPouch.Id, sakuraSeedPouch); (ethernalPoseThrillerBark.Id, ethernalPoseThrillerBark) ]
      AvailableItems = Map.empty
      NextLocation = Map.ofList [ (West, "thriller_bark"); (East, "kano_country") ]
      Riddles = westBlueRiddles 
      NextLocationUnlockRequirements = Map.ofList [ (West, {RequiredItemId = Some sakuraSeedPouch.Id}); (East, {RequiredItemId = Some ethernalPoseThrillerBark.Id}) ]
    }

let east_blue =
    { Id = "east_blue"
      Name = "Bartie Floating Restaurant"
      Description = """
      The Bartie Floating Restaurant sways gently on the waves, its hull patched with mismatched wood and pride. 
      The scent of seared sea king meat and Sanji’s infamous “Love-Cooked” stew wafts through the air. 
      Pirates and fishermen shout over clinking mugs, their laughter punctuated by the occasional splash of a sous chef gutting fish. 
      To the east, the horizon glows with the promise of Dawn Island. 
      A chalkboard menu reads: “Today’s Special: Adventure, served with a side of danger.
      """
      UnavailableItems = Map.ofList [ (sanjiSecretSpice.Id, sanjiSecretSpice); (loguetownFerryTicket.Id, loguetownFerryTicket) ] 
      AvailableItems = Map.empty
      NextLocation = Map.ofList [ (West, "arlong_park"); (East, "logue_town") ]
      Riddles = eastBlueRiddles 
      NextLocationUnlockRequirements = Map.ofList [ (West, {RequiredItemId = Some sanjiSecretSpice.Id}); (East, {RequiredItemId = Some loguetownFerryTicket.Id}) ]
    }

let thriller_bark =
    { Id = "thriller_bark"
      Name = "Persona's Garden of Horrors"
      Description = """
      A wall of fog parts to reveal Thriller Bark, a rotting galleon the size of a city, its mast piercing the moonlit sky. 
      Shadows of zombies shuffle in the distance, their moans harmonizing with the creak of the ship’s cursed timbers. 
      The ground squelches beneath your feet, a mix of swamp mud and… something worse. 
      Jack-o’-lanterns leer from skeletal trees, their flames flickering green. 
      Somewhere deep in the mist, a deep voice chuckles: “Kishishishi…* Welcome to my playground.
      """
      UnavailableItems = Map.ofList [ (brookViolinBow.Id, brookViolinBow); (geckoMoriaShadowSnips.Id, geckoMoriaShadowSnips) ] 
      AvailableItems = Map.empty
      NextLocation = Map.ofList [ (West, "west_blue"); (East, "new_world") ]
      Riddles = thrillerBarkRiddles 
      NextLocationUnlockRequirements = Map.ofList [ (West, {RequiredItemId = Some geckoMoriaShadowSnips.Id}); (East, {RequiredItemId = Some brookViolinBow.Id}) ]
    }

let kano_country =
    { Id = "kano_country"
      Name = "Wano’s Flower Capital Outskirts"
      Description = """
      Cherry blossoms rain down as you step into the shadow of Wano’s Flower Capital. 
      The opulent rooftops of the city gleam in the distance, but here, the outskirts are a patchwork of rice paddies and crumbling samurai graves. 
      A rusted katana lies half-buried in the soil, its hilt wrapped in a fading hachimaki. 
      The wind carries the clang of swords from Kaido’s fortress and the faint hum of a shamisen. 
      A weathered sign warns: “Beware the Kurozumi’s curse.
      """
      UnavailableItems = Map.ofList [ (ryumaShusuiCloth.Id, ryumaShusuiCloth); (seastoneHandcuffKey.Id, seastoneHandcuffKey) ] 
      AvailableItems = Map.empty
      NextLocation = Map.ofList [ (West, "west_blue"); (East, "new_world") ]
      Riddles = kanoRiddles 
      NextLocationUnlockRequirements = Map.ofList [ (West, {RequiredItemId = Some seastoneHandcuffKey.Id}); (East, {RequiredItemId = Some ryumaShusuiCloth.Id}) ]
    }

let arlong_park =
    { Id = "arlong_park"
      Name = "Nami’s Chart Room"
      Description = """
      Arlong Park’s jagged coral towers rise from the shallows like the ribs of a drowned leviathan. 
      Saltwater canals cut through the ruins, their surfaces choked with seaweed and shattered dream charts. 
      In Nami’s hidden Chart Room, parchment maps plaster every wall—each one meticulously detailed, each stained with tear-smudged ink. 
      A rusted sextant sits on a desk, its needle still pointing to Cocoyasi Village. 
      The air tastes of salt and swallowed rage.
      """
      UnavailableItems = Map.ofList [ (completeGrandLineChart.Id, completeGrandLineChart); (climaTactPrototype.Id, climaTactPrototype) ] 
      AvailableItems = Map.empty
      NextLocation = Map.ofList [ (West, "new_world"); (East, "east_blue") ]
      Riddles = arlongRiddles 
      NextLocationUnlockRequirements = Map.ofList [ (West, {RequiredItemId = Some completeGrandLineChart.Id}); (East, {RequiredItemId = Some climaTactPrototype.Id}) ]
    }

let logue_town =
    { Id = "logue_town"
      Name = "Gol D. Roger’s execution Platform"
      Description = """
      The wooden gallows of Roger’s execution platform dominate LogueTown’s square, its ropes frayed but still swinging in the stormy breeze. 
      Vendors hawk “Pirate King” souvenirs nearby, their voices drowned out by the crash of waves against the harbor. 
      The scent of gunpowder lingers—remnants of Buggy’s last fireworks display. 
      A cracked cobblestone bears Roger’s final grin, preserved in bronze. Above, storm clouds swirl as if the sky itself debates your destiny.
      """
      UnavailableItems = Map.ofList [ (rogerLastWordsEchoShell.Id, rogerLastWordsEchoShell); (smokerJitteTip.Id, smokerJitteTip) ] 
      AvailableItems = Map.empty
      NextLocation = Map.ofList [ (West, "new_world"); (East, "east_blue") ]
      Riddles = logueRiddles 
      NextLocationUnlockRequirements = Map.ofList [ (West, {RequiredItemId = Some rogerLastWordsEchoShell.Id}); (East, {RequiredItemId = Some smokerJitteTip.Id}) ]
    }

let new_world =
    { Id = "new_world"
      Name = "Gol D. Roger’s execution Platform"
      Description = """
      Rafael’s Shore is a graveyard of ambition. 
      The black sand burns underfoot, littered with the splintered hulls of ships that dared challenge the New World. 
      Whirlpools churn on the horizon, their depths glowing with bioluminescent predators. 
      A lone Road Poneglyph juts from the surf, its red glyphs humming with the weight of the Void Century. 
      The air crackles with static—a warning from the heavens. Somewhere beyond the tempest, Laughtale laughs.
      """
      UnavailableItems = Map.ofList [ (ancientTranslationKey.Id, ancientTranslationKey); (willOfDInheritance.Id, willOfDInheritance) ] 
      AvailableItems = Map.empty
      NextLocation = Map.empty
      Riddles = newRiddles 
      NextLocationUnlockRequirements = Map.empty
    }


//---- CREATING THE ONE PIECE WORLD AND INITIAL STATES ----
let initialGameWorld : Map<string, Location> =
    Map.ofList [
        (entrance.Id, entrance);
        (west_blue.Id, west_blue);
        (east_blue.Id, east_blue);
        (thriller_bark.Id, thriller_bark);
        (kano_country.Id, kano_country);
        (arlong_park.Id, arlong_park);
        (logue_town.Id, logue_town);
        (new_world.Id, new_world) 
    ]

let initialPlayer : Player = { CurrentLocationId = entrance.Id; Inventory = [] }

let initialGameState : GameState =
    { Locations = initialGameWorld
      Player = initialPlayer
      MessagesToDisplay = ["Welcome to One Piece Adventure!"]
      IsGameOver = false
    }