cd /etc/init.d

case $1 in
	start)
     		sudo rm daemon
		sudo cp /home/volander/daemon /etc/init.d
		sudo update-rc.d daemon defaults
		sudo start-stop-daemon -Sx daemon
     	;;
  	stop)
     		sudo start-stop-daemon -Kvx daemon
     	;; 
	*)
		echo "Используйте: $0 {start|stop}"
	;; 
esac
