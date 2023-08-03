#### **Group Members:** Zahra Jaleh & Vahid Mousavinezhad

<img src="images/CheesyMath_logo.png" alt="alt text" width="200" height="200" align="center">

# **Cheesy Math**

The goal of this project is to determine how much the quality of performance of the human brain to solve easy math problems will differ when individuals are only focusing on solving math puzzles, as opposed to when they are playing a video game. We also consider another criterion, which is the interaction errors between the two players. To achieve this, we have developed a runner game in which the character (Mousy) will be controlled by two players. During the game, they must collect as much cheese as they can and also answer all the math puzzles. After conducting the experiments, we will report the error rates based on the players' performances. The idea will be discussed in detail in the following sections.


## **Research Question**

**How does playing video games affect human brain performance in solving easy math problems?**

We ask one of the players to answer 10 math questions within 1 minute (6 seconds for each question) before the game. Then, during the game, they have to answer similar questions, allowing us to measure the differences in their math-solving performance.

Also, During the game, a supervisor annotates the answers of player one (who can see the screen and, by giving commands to player two, attempts to answer the questions). In this case, we can monitor the errors caused by the interaction problem between the two players.


## **Modalities**

**Input:** Movement(Smarphone Motion Sensor), Touch(Laptop touchpad), Heart Rate(Bitalino)

**Output:** Sound, Vibration


## **Emotional Model**

**Flow:** Change the speed of the character based on the changes in heart rate (HR). In different levels of difficulty, the HR will change, with higher HR as the difficulty increases.[^1]

Before starting the game, we establish a baseline for player one's heart rate (HR) by calculating the mean. During the game, we dynamically adjust the character's speed based on the fluctuations in the player's heart rate mean.


## **Tools and Applications**

**Unity3D:** It's a powerful cross-platform game engine used for developing video games, virtual reality (VR) and augmented reality (AR) applications. It comes with an extensive set of tools, a friendly user interface, and a robust scripting API that uses C#.[^2]

**Visual Studio Code:** A streamlined code editor with support for development operations like debugging, task running, and version control.[^3]

**Bitalino and Open Signal:** It's a device used for heart rate acquisition. Open Signal is its corresponding app designed to collect and transfer data to other applications.[^4]

**Unity Asset Store:** It's an online marketplace provided by Unity Technologies where developers can find various digital assets to use in their Unity game development projects. These assets can include 3D models, 2D textures, animations, audio files, and more.[^5]

**Unity Remote:** Unity Remote is a downloadable application that helps with Android and iOS development. It sends live inputs from the target device back to the running project in Unity.[^6]

**Adobe Photoshop:** A photo editor application that is used for creating the game logo and logo display scene.[^7]

**Adobe Premier Pro:** A video and sound editor application that is used to edit the original music into a piece of proper loop music for the game.[^7]


## **Assets**
**1. Character and its animations:** 
- https://www.mixamo.com/ [^8]

**2. Environment:** 
- https://assetstore.unity.com/packages/3d/environments/industrial/rpg-fps-game-assets-for-pc-mobile-industrial-set-v2-0-86679
- https://assetstore.unity.com/packages/tools/utilities/tg-utility-131460
- https://assetstore.unity.com/packages/3d/props/food/free-casual-food-pack-mobile-vr-85884
- https://assetstore.unity.com/packages/3d/environments/roadways/road-props-for-games-diffuse-map-atlas-lp-238835
- https://assetstore.unity.com/packages/3d/vehicles/controllable-forklift-free-80275


**3. Sound FX:** 
- https://assetstore.unity.com/packages/audio/sound-fx/8-bits-elements-16848

**4. Music:** 
- https://assetstore.unity.com/packages/audio/music/rock/funky-blues-rock-jam-free-118085


## **References**
[^1]:Tian Y, Bian Y, Han P, Wang P,Gao F and Chen Y (2017) Physiological Signal Analysis for Evaluating Flow during Playing of Computer Games of Varying Difficulty. Front. Psychol. 8:1121. doi: 10.3389/fpsyg.2017.01121
[^2]:https://unity.com/
[^3]:https://code.visualstudio.com/
[^4]:https://www.pluxbiosignals.com/
[^5]:https://assetstore.unity.com/
[^6]:https://docs.unity3d.com/Manual/UnityRemote5.html
[^7]:https://www.adobe.com/
[^8]:https://www.youtube.com/watch?v=2-_V0ZuB2eA&t=354s

