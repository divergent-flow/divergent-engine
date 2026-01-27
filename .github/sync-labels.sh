#!/bin/bash

# Repository to sync to
REPO="divergent-flow/divergent-engine"

# Ensure we are in the script's directory
cd "$(dirname "$0")"

if [ ! -f "labels.json" ]; then
    echo "Error: labels.json not found in $(pwd)"
    exit 1
fi

echo "Syncing labels to $REPO..."

# Read labels.json and loop through each entry
cat labels.json | jq -c '.[]' | while read -r label; do
  name=$(echo $label | jq -r '.name')
  color=$(echo $label | jq -r '.color')
  description=$(echo $label | jq -r '.description')
  
  echo "Processing: $name"

  # Try to create the label first
  # We suppress stderr here to avoid "already exists" noise, but we capture exit code
  gh label create "$name" \
    --repo "$REPO" \
    --color "$color" \
    --description "$description" \
    --force >/dev/null 2>&1
  
  # Check if creation successful
  if [ $? -eq 0 ]; then
    echo "  - Created"
  else
    # Creation failed (likely exists), try to update
    gh label edit "$name" \
        --repo "$REPO" \
        --color "$color" \
        --description "$description" \
        --force >/dev/null 2>&1
        
    if [ $? -eq 0 ]; then
        echo "  - Updated"
    else
        echo "  - Failed to sync"
    fi
  fi
done

echo "Done!"
