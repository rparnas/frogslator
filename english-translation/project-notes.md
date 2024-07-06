# Project Notes

## History
In 2008, I was spending a semester in Japan and talked with some students (in English, my Japanese isn't great) about games. Kaeru came up. At the time, the Mother 3 translation blogged a lot of technical details and I was like, “I halfway understand what they are doing.”

Project goals and team roles developed over time. If I had to do it again, I would try to define them ahead of time. Loosely, the mission was "translate and localize the game as if it had been released professionally in the early 90s”. The project progressed as follows:

* Hacking (14 months)
* Initial Translation by Eien Ni Hen (8 months)
* Hacking/Inserting Translated Text (5 months)
* First Beta (1 month)
* Processing Beta Feedback (4 months)
* Text Overhaul with Brandon and Devin(3 months)
* Second Beta (1 month)
* Additional Text Iteration (3.3 months)

My approach on the tech side was to keep things simple. No knowledge of ASM or program code was used. Mostly just the dialog data and a few graphics were edited. 

The ROM was not expanded. Normally, this would have an adverse effect on quality as English takes up about 1.5 times as much space as Japanese. This was mitigated somewhat by the fact there is 15% empty space in the dialog part of the ROM, and the original text is a bit kiddish and spells things out, using more space for Japanese text than everyday Japanese.

For the translation itself, the first pass focused on a raw translation of the text and documenting all the cultural references. After that, I was contacted by a writer and a game design instructor who had a lot of thoughts for taking the script to the next level. They drove a second phase of intense iterations on the script from a "writer's first" perspective. I feel this worked really well and I recommend having both a writer and a translator be represented on teams. 

A lot of the text work also involved not just the wording but the timing and pacing of how words appear on the screen. This is important especially for comedy.

## Translation Philosophy
In any translation, there is a tension between translation (introducing foreign culture to the audience) and localization (seamlessly adapting local culture while preserving the ideas and feelings of the original). Neither is inherently good or bad. Either can be done poorly such as a translation that is too literal to understand or a localization that ignores the original meaning.

The weakest parts of our patch might be leaning too much towards translation. For example, I'm pretty sure Nintendo would have renamed wine to something else. However, it's not that Nintendo localizes all Japanese culture out of their games. Consider how weird a Nintendo game seems to someone who has never played one before. But I think what Nintendo does well is put themselves in the shoes of players who don't know about their culture. This is important as they sell games to each new generation of kids.

It's not that we made some parts translate on purpose. It's just that we were immersed in the culture of the game (as are many Nintendo fans) and had only a certain skill level for detecting what feels unnatural to others.

A good translation isn't just about individual words or lines. The comment about accenting the e in Sable is an interesting example. A lot of the game is named for snacks. Where I live in the US, things like cookies are common. In Japan, snacks are more of a delicacy. There are a lot more bakeries as few people own ovens. Specific cookies might be referred to by their technical names, such as the French word sablé. But what is the game trying to get across from this?

It's expressing that the game shouldn't be taken seriously. On a deeper level, it's sharing the fun and culture of the R&D department that made the game. They didn't take _making_ the game too seriously and nerds that they are, their lunchtime conversations moved seamlessly from things like technical discussions to arguing about the minutiae of nearby restaurants. 

Maybe staying with highly technical terms of snacks is too wordy and doesn't get that the game makers are making fun of themselves across. A lot of this cultural context I didn't get when we were making the patch and it would probably be a major overhaul to improve.

But what I'm really reflecting on is that in making a translation I recommend thinking about the big picture and developing broad rules of thumb first. Answer questions like "why are we talking about snacks in the first place?" Then decisions about individual words can then more easily fall into place.