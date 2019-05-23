bold=$(tput bold)
normal=$(tput sgr0)
echo "${bold}*** Mover Server ***${normal}"

export SSHPASS='enterro2019'

MACHINE_USERNAME=p2g1
MACHINE_HOSTNAME=192.168.160.80

echo -e "\n${bold}->${normal} A mover Server para a máquina ${bold}p2g1@192.168.160.80${normal}"
sshpass -e scp -o StrictHostKeyChecking=no server.sh $MACHINE_USERNAME@$MACHINE_HOSTNAME