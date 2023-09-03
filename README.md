# BDOAlchemyStoneTapper
 [中文版](/README_CN.md)

A project that automates BDO alchemy Stone tapping, with the help of yolov8 visual object 
detection and simulated key strokes.

- V1.1.0 version and onwards supports both polish and grow
- Any version of BDO works, no matter the language and server.
- It saves a lot of time tapping stones but it might get you banned so be careful with it.

## Table of contents

- [Tutorial](#Tutorial)
- [To do](#To-Do)
- [What's included](#whats-included)
- [Creators](#creators)
- [Copyright and license](#copyright-and-license)

## Tutorial
1.Open software in administrator mode
![1](MarkDownImages/Tutorial1.png)

This is so the software gains the ability to simulate mouse clicks and keyboard inputs

2.Select Stone type and select the stones to polish/grow
![2](MarkDownImages/Tutorial2.png)
3.Select Working are with the Green border
![3](MarkDownImages/Tutorial3.png)
4.Open Polish/Grow window and press button to start
![4](MarkDownImages/Tutorial4.png)
```
Heads up:
     1.select skip animation and select "max number" before starting
     2.Make sure Alchemy stones and materials are detected.
     3.Make sure there is enough material in the inventory.
     4.CTRL + alt + DEL is the only way to break the program as it is using 
     dirextX keyboard input.
```

## To-Do

This is a hobby project so don't expect too much.

- [ ] Automated restocking
- [ ] Material existence check during tapping
- [ ] Black stone existence check during tapping
- [ ] Better AI model
- [ ] More localizations
- [ ] Manually set Material/BlackStone locations
## What's included

[Grab compiled package here](https://github.com/NAinfini/BDOAlchemyStoneTapper/releases)

```text
BDOAlchemyStoneTapper
    ├──Destruction.onnx                 Model for Destruction stones
    ├──Protection.onnx                  Model for Protection stones
    ├──Life.onnx                        Model for Life stones
    ├──BDOAlchemyStoneTapper.exe    Executable
    ├──DefaultLanguage.json             English language
    ├──DefaultLanguage_cn.json          Chinese language
    └──RunTime files                    Required runtime files
```

## Creators

[NA_infini](https://github.com/NAinfini)

## Copyright and license

Code released under the [MIT License](https://reponame/blob/master/LICENSE).

Enjoy :metal:
