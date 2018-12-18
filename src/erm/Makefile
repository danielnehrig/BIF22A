LIB = -r:System.data
COMP = mcs
FILENAME = Program.exe

Server:
	$(COMP) ./src/server/inventar.cs $(LIB) -o $(FILENAME)
	mv ./$(FILENAME) ./dist/server/$(FILENAME)
	cp ./src/server/config.cfg ./dist/server/config.cfg


test:
	echo 'todo'

clean:
	rm ./dist/server/*.exe
	rm ./dist/server/config.cfg
