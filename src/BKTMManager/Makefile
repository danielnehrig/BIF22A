LIB = -r:System.data
PKG = -pkg:dotnet
COMP = mcs
SRCPATH = ./src/server/
COMPILEPATH = ./dist/server/
FILENAME = BKTMManager.exe

Build:
	$(COMP) -recurse:*.cs $(LIB) -out:$(FILENAME)
	mv ./$(FILENAME) $(COMPILEPATH)$(FILENAME)
	cp $(SRCPATH)config.cfg $(COMPILEPATH)config.cfg

Clean:
	rm ./dist/server/*.exe
	rm ./dist/server/config.cfg
