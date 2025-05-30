.PHONY: restore build test clean publish watch run migration

SOLUTION_DIR := .
SRC_DIR := $(SOLUTION_DIR)/src
TEST_DIR := $(SOLUTION_DIR)/tests
ENTRY_PROJECT := $(SRC_DIR)/Web/Web.csproj
INFRASTRUCTURE_PROJECT := $(SRC_DIR)/Infrastructure/Infrastructure.csproj
SOLUTION := $(SOLUTION_DIR)/CleanApi.slnx
NUGET_CONFIG := $(SOLUTION_DIR)/nuget.config
DB_CONTEXT := ApplicationDbContext
CONFIGURATION ?= Debug

restore:
	dotnet restore $(ENTRY_PROJECT) --configfile $(NUGET_CONFIG)

build:
	dotnet build $(ENTRY_PROJECT) --configuration $(CONFIGURATION)

test:
	dotnet test $(SOLUTION) --configuration $(CONFIGURATION) --verbosity normal

clean:
	@echo "Cleaning build outputs and test results..."
	@find $(SOLUTION_DIR) -type d \( -name "bin" -o -name "obj" -o -name "publish" \) -exec rm -rf {} + 2>/dev/null || true
	@if [ -d "$(SOLUTION_DIR)/TestResults" ]; then \
		rm -rf $(SOLUTION_DIR)/TestResults; \
	fi
	@echo "Clean completed successfully"

publish:
	dotnet publish $(ENTRY_PROJECT) --configuration Release --output $(SOLUTION_DIR)/publish

watch:
	dotnet watch --project $(ENTRY_PROJECT) run --configuration $(CONFIGURATION)

run:
	dotnet run --project $(ENTRY_PROJECT) --configuration $(CONFIGURATION)

migration:
	@if [ -z "$(name)" ]; then \
		echo "Error: migration name is required. Usage: make migration name=YourMigrationName"; \
		exit 1; \
	fi
	@echo "Adding migration: $(name)"
	dotnet ef migrations add "$(name)" --project $(INFRASTRUCTURE_PROJECT) --startup-project $(ENTRY_PROJECT) --context $(DB_CONTEXT)
