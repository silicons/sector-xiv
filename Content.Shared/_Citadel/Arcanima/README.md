# Project Arcanima

"and silicons didn't ask whether they should, instead they asked whether they could"

`Arcanima` is, at this point, a virtual-pseudo-ISA used to implement features where
heavily dynamic content is desired. Like, say, Xenoarch, with its ability for players
to harness the power of artifacts, occult spells for the Eldritch module, and nanite-swarm programming.

Unlike Hexcasting and other systems, this is not _strictly_ an assembly analogue; instead, it's
built with 'hook points' for various game systems and is ultimately specialized for the game itself.

The entire system is built with 'forking' in mind; a program splitting into multiple active components,
because not all spells are 'fire and do one thing at a time' with hitscan in this game. Most aren't, actually!

## Engine

TODO: Re-document this after the dust settles.

### Glyphs

The smallest unit of Arcanima is a glyph. Glyphs are the 'instructions' that make up a program.

### Programs

A program is a compiled Arcanima program.

They are immutable, because the Carriers ticking on them need to reference their data without worrying about it
changing, including memory keys and more.

### Invocations

An invocation is a running instance of a program, with one or more carriers.

Invocations have a shared tracking of the following:

- Memory Units - approximate memory used by invocation. Exceeding configured limits will hard-kill the invocation.
- Compute Units - approximate compute used by invocation. Invocation as a whole (all carriers) get throttled if this
  goes too high.
- Lifetime - how much 'physical presence' the invocation has left. Un-moving carriers tend to drain this a lot less.

### Carriers

A carrier is an 'operational head' of a program. They're something like a tile, an entity (projectile, lingering thing,
mobile object, etc), 'attached' to another entity (separate from being the entity itself), and more.

Carriers may emit signals that trigger certain behaviors in the program.

### Memory

All invocations have their own memory space, shared between all carriers.

This consists of a key-value store that can hold a variety of data types.
