init:
	dotnet restore

generate-crds:
	dotnet run -- generator crd -o ./config/crds

install:
	dotnet run -- install

uninstall:
	dotnet run -- uninstall
