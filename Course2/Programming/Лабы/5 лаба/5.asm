.model small
.data 
message1 db "Input N:",0Dh,0Ah,'$'; $- конец строки
message2 db "Input M:",0Dh,0Ah,'$'
message3 db "a[$"
message4 db ", $"
message5 db "] = $",0Dh,0Ah,'$'
message6 db "Result = "
newline db   0Dh, 0Ah,'$' ; перевод строки 
n dw ?
m dw ?  
matrix dw 1000 dup (?)
.stack 100h
.code  
InputInt proc 
    mov ah,0ah
    xor di,di
    mov dx,offset buff
    int 21h 
    mov dl,0ah
    mov ah,02
    int 21h 
    mov si,offset buff+2 
    cmp byte ptr [si],"-" 
    jnz il
    mov di,1  
    inc si  
il:
    cmp byte ptr [si],"+" 
    jnz ii1
    inc si 	
ii1:
    xor ax,ax
    mov bx,10 
ii2:
    mov cl,[si] 
    cmp cl,0dh  
    jz endin
    cmp cl,'0' 
    jl er
    cmp cl,'9'  
    ja er
 
    sub cl,'0' 
    mul bx     
    add ax,cx  
    inc si    
    jmp ii2    
 
er:  
    mov dx, offset error
    mov ah,09
    int 21h
    int 20h
endin:
    cmp di,1 
    jnz ii3
    neg ax   ; делаем число отрицательным
ii3:
    ret
 
error db "incorrect number$"
buff    db 6,7 Dup(?)
InputInt endp

OutInt proc
test    ax, ax
jns     oi1
    mov  cx, ax
    mov     ah, 02h
    mov     dl, '-'
    int     21h
    mov  ax, cx
    neg     ax
oi1:  
    xor     cx, cx
    mov     bx, 10 
oi2:
    xor     dx,dx
    div     bx
    push    dx
    inc     cx
    test    ax, ax
    jnz     oi2
    mov     ah, 02h
oi3:
    pop     dx
    cmp     dl,9
    jbe     oi4
    add     dl,7
oi4:
    add     dl, '0'
	
    int     21h
    loop    oi3
    
    ret 
OutInt endp 

InputMatrix proc
	xor si, si; индекс по строкам	
	xor dx, dx ; dx используется для вывода на экран номера вводимой строки
	xor di, di ; di используется для вывода на экран номера вводимого столбца
	lea bx, matrix
	mov cx, n	;количество строк
	row: ; цикл по строкам
		push cx			
		inc dx ; увеличиваю на 1 сразу, чтоб номера индексов шли по-христеански( с 1)
		mov cx, m			
	col: ; цикл по столбцам			
		inc di ; тоже что и с dx
		
		push cx; т.к. в OutputString и InputInt cx будет менять значение, добавляем его в стек
		push bx; тоже шо и с cx
		push si
		push dx
		push di
		
		call OutputString		
		call InputInt
		
		pop di
		pop dx
		pop si
		pop bx
		pop cx
		
		mov [bx][si], ax 
		add si, 2	
		loop col		
		pop cx
		xor di, di
		loop row
	ret		
endp InputMatrix	

OutputString proc ; выводит ячейку, куда добавиться элемент
	push di	
	push dx
	lea dx, message3
	call Output	; выводит: "a["
	pop ax
	call OutInt ; выводит номер строки, что в ax
	lea dx, message4
	call Output ; выводит: ", "
	pop ax ; достаем из стека номер столбца
	call OutInt ; ясно как божий день
	lea dx, message5
	call Output ; выводит: "] = "
	ret
endp OutputString	
	
OutputMatrix proc
	xor si, si; индекс по строкам
	lea bx, matrix
	mov cx, n	;количество строк
	row1: ; цикл по строкам
		push cx	
		mov cx, m
	col1: ; цикл по столбцам	
		mov ax, [bx][si] ;записываем число в si-строку в позицию di
		push bx
		push cx
		call OutInt
		pop cx
		pop bx		
		add si, 2
		loop col1
		xor di, di; закончился цикл по столбцам. Поэтому обнуляем регистр
		pop cx
		loop row1
	ret		
endp OutputMatrix

Summa proc
	xor si, si
	xor di, di ; отвечает за количество суммируемых элементов в каждой строчке
	xor dx, dx ; тут будет храниться сумма элементов ниже главной диагонали
	lea bx, matrix
	mov cx, n
	row3:
		push cx ; по строкам
		mov cx, m
		push cx ; по столбцам
	col3:	
		mov cx, di ; сколько элементов суммировать в текущей строке
		inc cx ; т.к. loop уменьшает значение cx на 1
		loop sum
		after_sum:
			pop cx ; значение по столбцам
			sub cx, di ; узнаем сколько еще элементов в строке нужно обойти			
		bypass_string: ; заверщает обход строки и переходи на новую строку
			add si, 2		
			loop bypass_string	
		inc di ; в следующей строке количество суммируемых элементов увеличится на 1	
		pop cx
		loop row3
		jmp final
	sum:	
		add dx, [bx][si]
		add si, 2
		loop sum
		jmp after_sum	
	; результат сохраняется в dx		
	final:
		ret
endp Summa

Output proc
	mov ah, 9
	int 21h
	ret
endp Output

start:
	mov ax, @data
	mov ds, ax
	mov es,ax
	
	; вводим количество строк
	mov dx, offset message1
	call Output  
	call InputInt
	mov n, ax
	
	; вводим количество столбцов	
	mov dx, offset newline
	call Output
	mov dx, offset message2
	call Output
	call InputInt
	mov m, ax	
	
	;ввод матрицы
	call InputMatrix	
	
	lea dx, message6
	call Output
	;call OutputMatrix
	
	; подсчет суммы элементов под нижней диагональю
	call Summa
	mov ax, dx
	call OutInt
	call InputInt
	mov ax, 4c00h
    int 21h  
end start