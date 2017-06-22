.model small
.data 
message1 db "Input string:",0Dh,0Ah,'$'; $- конец строки
message2 db "Result:", ,0Dh,0Ah,'$'
newline db   0Dh, 0Ah,'$' ; перевод строки 
vo db "eEyYuUiIoOaA"; гласные буквы
buffer db 100  
bsize db ?
bcontent db dup 100 (?)  
.stack 100h
.code  

Input proc
	mov ah, 0Ah
	int 21h
	ret
endp Input

Output proc
	mov ah, 9
	int 21h
	ret
endp Output

start:
	mov ax, @data
	mov ds, ax
	mov es,ax
	
	mov dx, offset message1
	call Output  
	mov dx, offset buffer
	call Input  
	
	xor di,di    
	xor cx,cx
	mov cl,bsize
	mov si,cx ; в si длинна строки  
	mov bcontent[si],'$'  
	xor ax,ax  	
    vowel:
      mov bl,byte ptr bcontent[di] 
      xor bh,bh
      push si 
      xor si,si
     sravnenie:
       cmp bl,vo[si]
       je nashel_bukvu
       inc si
       cmp si,12
       jb sravnenie
       jmp next
	  nashel_bukvu:
		cwd
		mov ax, di
		add ax, 1
		mov cx, 2
		idiv cx
		cmp dx, 1
		je bukva_na_nechetnoy_positsii
		jmp next
      bukva_na_nechetnoy_positsii:    
        mov ax, di
		add ax, 1
		add ax, 30h
		mov bcontent[di], al        
      next:   
         inc di  
         pop si
         cmp  di,si    
         jb vowel  
	mov dx, offset newline
	call Output
	mov dx, offset message2
	call Output
	mov dx, offset bcontent
	call Output  
	
    mov ax, 4c00h
    int 21h  
end start

