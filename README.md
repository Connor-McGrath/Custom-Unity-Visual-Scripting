# Custom Unity Visual Scripting
A workshop space to tinker with how to make new custom nodes.


## Plans
- Node Descriptors for every custom node
- ~~Multi-Input Multiplication Node~~
    - ~~Subtraction and Division as well~~
- ~~Layermask comparison~~
    - ~~Flow-Branching Select-Style node based on object layer~~
        - Fix UI Issues: Faulty inspector selection and replace indices with layer names
- ~~Bitwise and Binary operators~~
    - Better interface, display the binary digits
    - Custom svg's for icons? Is this possible?
    - Verify the logic is correct, i.e. negatives and edge cases
        - Support more options than just int? Do shorts/bytes have any value in being added to the scripting graph?
- Multi-Input boolean operators and maybe some others
- Rounding to specific amounts of decimals
    - Component-wise support for vectors
    - [More planning required] Extra node that will avoid rounding to important breakpoints (e.g. dont display 0 health while on 0.3, display 1)
