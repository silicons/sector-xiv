# World Generation

Module responsible for Citadel's world generation system.

## Architecture

All world generation is *required* to be done off-main-thread.

This ensures Citadel can, in the future, perform intensive tasks without bogging down server performance.
While not technically a concern right now, it's preferable to have the system in place rather than
to have to redo everything to be threaded later.
