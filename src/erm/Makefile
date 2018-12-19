LIB = -r:System.data
PKG = -pkg:dotnet
COMP = mcs
FILENAME = Program.exe

Server:
	make clean
	$(COMP) -recurse:*.cs $(LIB) -out:$(FILENAME)
	mv ./$(FILENAME) ./dist/server/$(FILENAME)
	cp ./src/server/config.cfg ./dist/server/config.cfg


test:
	echo 'todo'

clean:
	rm ./dist/server/*.exe
	rm ./dist/server/config.cfg
