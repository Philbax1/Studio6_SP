Set WshShell = CreateObject("WScript.Shell")
MsgBox ConvertToKey(WshShell.RegRead("HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\DigitalProductId"))

Function ConvertToKey(Key)
Const KeyOffset = 52
i = 28
Chars = "BCDFGHJKMPQRTVWXY2346789"
Do
Cur = 0
x = 14
Do
Cur = Cur * 256
Cur = Key(x + KeyOffset) + Cur
Key(x + KeyOffset) = (Cur \ 24) And 255
Cur = Cur Mod 24
x = x -1
Loop While x >= 0
i = i -1
KeyOutput = Mid(Chars, Cur + 1, 1) & KeyOutput
If (((29 - i) Mod 6) = 0) And (i <> -1) Then
i = i -1
KeyOutput = "-" & KeyOutput
End If
Loop While i >= 0
ConvertToKey = KeyOutput
End Function


# Studio2_SP

Similar Games
- A Hat in Time
- Ty the Tasmanian Tiger
- Crash Bandicoot
- Prince of Persia 1989
- Super Mario 64
- Yooka Laylee


Possible enemies
- Takes a second and then cahrges at player on contact bumps player back.
- Locks onto player in range and fires projectile at them every few seconds.
- Shark, patrols water for enemy to fall in


Puzzles
- 

Console issue
https://answers.unity.com/questions/1137110/invalid-editor-window-unityeditorfallbackeditorwin.html
