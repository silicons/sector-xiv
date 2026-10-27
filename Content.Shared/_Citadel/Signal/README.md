# Signals

Core system for signal modeling in Sector XIV.

Signals are representations of transmissions, connections, and beacons;
the unavailability of perfect information is a core mechanic in Sector XIV.

As an example, radio transmissions may be jammed, blocked by terrain / walls, out of range,
and receivers would handle it appropriately (e.g. entirely dropping the transmission or
garbling the words due to noise.)

This is also used for positioning. Positioning in Sector XIV must be to a reference frame.

Usually, things like ships use static frames of reference (the stars are treated to be
immobile for purposes of game sim ~~unless Storytellers decide it's time for horrors
beyond comprehension~~), but to position to **each other** - or even to a **planet** or other mobile
object, generally some kind of signal (or visual lock) must be obtained.

## Core Simulation

tl;dr:

Signals are simulated on a specific SignalMap. This is a 2D plane more or less.

There's three basic concepts.

- Beacons - Passive signals that are constantly emitted from a source.
- Pulses - Active pulses that are emitted once.
- Fields - Modifiers (jammers, disruptors, and more) to signals nearby.
- Listeners - Receivers;
    - They get delegates (callbacks) for when a beacon goes in or out of 'potentially receivable set' range.
    - They get delegates (callbacks) for burst transmissions.

