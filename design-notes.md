# Gameplay Implementation:

- 2D sidescroller/runner
- Must pick one of three dialogue choices, which then is executed by a command:
- action command/ wario-ware style mini 'games' (inputs) to execute sending
the command
- Two things happening: stability and action commands
- add difficulty: closer keyboard messups

- Detective game movie
- 

# Game summary:
- Two 6 year olds are in a trenchcoat, posing as 12
- 12 year old pairs up with fake 12 year old to be 24 (in a trenchcoat)
- They all want to go to the PG-13 movie based on their favorite detective
video game.
- They team up, but 12 year old doesn't know that 6 year olds are two 6 year
olds.
- Sidescrolling (left to right) infinite runner game
- Game has two modes: Story mode and Endless mode
  - Story mode has intro and ending cutscene/comic
  (game ends at a certain distance, showing movie cutscene)
  - endless mode is the same gameplay, with no ending

# Story mode potential:
- Game begins as 6 year olds, same game (but 2 thought bubble choices)
- Then partway through, they meet the 12 year old, both recognize each other's
idea, then decide to team up

# Gameplay loop:
- Player character autoruns/walks forwards.
- Then, an "adult" (could *also* be two kids in a trenchcoat) walks towards you,
and asks a question. You choose from one of three answers (or two in (6+6) year
old mode).
- Choosing an answer initiates action command. We implement as many varieties of
commands as possible.
- Everything keeps moving on the screen at all times. If you don't choose an
answer to the question in time (before you walk past the asker), you get a
suspicion strike.
- If you utterly fail the action command, you get a suspicion strike.
- Three suspicion strikes and it's game over.
- Constantly, as you walk forward, your stability meter is decreasing. At any
time (except for the middle of another action command), you can press the
"restabilize" button to bring up a restabilization action command. Completing
this will slightly refill your stability meter, but failing will lose you some
more stability.
- If stability meter hits zero, you **immediately lose** (fill up all suspicion
strikes), as your stack of children collapses, and the ruse is revealed.

