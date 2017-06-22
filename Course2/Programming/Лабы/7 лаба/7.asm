.model small
.data
 path db "input.txt",0 ; имя файла для октрытия 
 resultpath db "output.txt",0 ; имя файла для сохранения результата
 buf  db ?
 n dw ?
 m dw ? 
 temp dw ? 
 matrix dw 1000 dup (?)
 message1 db "The number of rows: $"
 message2 db 0Dh,0Ah,"The number of columns: $"
 message3 db "Matrix: ",0Dh,0Ah,'$'
 message4 db 0Dh,0Ah,"Sum of the elements below the main diagonal: $"
 handle dw 0
 message_file_error db 0ah, 0dh, "Input error", '$'
 ten dw 10
.stack 100h
.486
.code

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

Output proc
	mov ah, 9
	int 21h
	ret
endp Output

; просто открываем файл и ничего с ним не делаем
OpenFile proc
	;открываем файл
	 mov ax,3d00h    ; открываем для чтения
    lea dx,path     ; DS:dx указатель на имя файла
    int 21h     ; в ax деcкриптор файла
    jc exit     ; если поднят флаг С, то ошибка открытия
    jmp norm
	exit:	
    mov ah,4ch
    int 21h
	norm:
    mov bx,ax       ; копируем в bx указатель файла
    xor cx,cx
    mov ax,4200h
    int 21h     ; идем к началу файла
ret
endp OpenFile	

; чтение из файла
; выполнять только после открытия файла
; читает посимвольно и переводит в число
; число хранится в ax
ReadFile proc
	mov temp, 0 ; здесь будет храниться число
	xor ax, ax
    xor dx,dx
read:	
	; считываем количество строк
	mov ah,3fh      ; будем читать из файла
    mov cx,1        ; 1 байт
    lea dx,buf      ; в память buf
    int 21h         
    cmp ax,cx       ; если достигнуть EoF или ошибка чтения
    jnz close       ; то закрываем файл закрываем файл
    mov dl,buf
	
	mov ah,2        ; выводим символ в dl
    int 21h 
	
	cmp dl, 13  ;эти 2 символа
	je read     ;идут в конце каждой строки парами
	cmp dl, 10  ;поэтому, когда встречаем первый, то переходим на метку
	je return   ;а когда второй, завершаем процедуру
	
	cmp dl, 20h ; проверка на то, является ли символ пробелом
	jne nextStep ; если не явлется, тогда переходим на метку	
	jmp return
   close:           ; закрываем файл, после чтения
    mov ah,3eh
    int 21h
	jmp return
nextStep:	
	mov al, dl
    sub al, 30h ; переводим символ в число
	xor ah, ah
	push ax	
	push bx
	mov ax, temp
	mov bx, 10
	imul bx
	mov temp, ax
	pop bx
	pop ax
	add temp, ax
	jmp read
	
return:
	mov ax, temp
	ret
endp ReadFile

InputMatrix proc
	mov temp, bx ; от bx зависит правильное чтение. почему -- хз
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
		
		mov bx, temp
		push bx
		
		call ReadFile
		
		pop bx
		mov temp, bx
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

Errorproc proc	;==============================================================
	push ax dx
	lea dx, message_file_error			; В случае ошибки						
	mov ah, 09h
	int 21h	
	pop dx ax
	
	mov ah, 4ch
	int 21h
	
	ret
Errorproc endp	

Summa proc
	xor si, si
	xor di, di ; отвечает за количество суммируемых элементов в каждой строчке
	xor ax, ax ; тут будет храниться сумма элементов ниже главной диагонали
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
		add ax, [bx][si]
		add si, 2
		loop sum
		jmp after_sum	
	; результат сохраняется в ax		
	final:
		ret
endp Summa

SaveResult proc	;==============================================================
	pusha	
	cld	
	mov temp, ax
	push ds
	pop es	
	xor ax, ax					; Создаём дескриптор
	xor cx, cx
	mov ah, 3ch
	lea dx, resultpath
	int 21h
	mov handle, ax
	
	jnc Save_file_created
	call Errorproc

Save_file_created:		
	lea di, buf
	
	mov al, 0dh
	stosb	
	mov al, 0ah
	stosb		
	mov bx, ax		
	mov si, ax		
	
	;;;;;;;;;;;;;;
	mov ax, temp
	call SaveNumber
	
	mov bx, handle
	mov ah, 40h
	lea dx, buf
	mov cx, di
	sub cx, dx
	int 21h
	
	mov ah, 3eh
	int 21h
	
	popa
	ret
SaveResult endp	;==============================================================

		
SaveNumber proc	;==============================================================
	push ax cx dx						; Приготовления	
	test ax, 1000000000000000b	; Отрицательное ли наше число
	jns SaveNumberNotNeg
	neg ax						; Если да - то меняем знак, и работаем, как с обычным
	push ax
	mov al, '-'					; Вдобавок выведем минус
	stosb	
	pop ax
	
SaveNumberNotNeg:
	xor cx, cx
	xor dx, dx
	
Save_DivideAgain:
	div ten										; Делим на 10, частное - в ax, остаток в dx и в стек
	inc cx
	push dx
	xor dx, dx
	cmp ax, 0									; До тех пор, пока частное не станет равным 0
	ja Save_DivideAgain
	
SaveSymbol:									; Выводим на экран циклом из стека
	pop dx
	push ax
	add dl, 30h									; Из цифры - код символа
	mov al, dl
	stosb
	pop ax
	loop SaveSymbol	
	
	;mov dl, ' '
	;int 21h
	
	pop dx cx ax
	ret
SaveNumber endp	;==============================================================	

begin:
	mov ax,@data ; настроим DS
    mov DS,ax       ; на реальный сегмент
    call OpenFile 
	
	lea dx, message1
	call Output	
	
	call ReadFile ; считываем количество строк
	mov n, ax	
	
	lea dx, message2
	call Output
	
	call ReadFile ; считываем количество столбцов
	mov m, ax	
	
	lea dx, message3
	call Output
	
	call InputMatrix ; вводится матрица
	
	lea dx, message4
	call Output
	
	call Summa
	push ax
	call OutInt
    
	mov ah,3eh ; закрываем файл, после чтения
    int 21h
	
	pop ax
	call SaveResult
    
	mov ah,01h
    int 21h
    mov ah,4ch
    int 21h
  end begin