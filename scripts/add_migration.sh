#!/bin/bash

root_dir=$(dirname "$(dirname "$(realpath "$0")")")

migration_name=$1
target_project="$root_dir/src/Infrastructure/Infrastructure.csproj"
startup_project="$root_dir/src/Web/Web.csproj"
context=ApplicationDbContext

echo "Adding migration '$migration_name'..."

dotnet ef migrations add $migration_name --project $target_project --startup-project $startup_project --context $context