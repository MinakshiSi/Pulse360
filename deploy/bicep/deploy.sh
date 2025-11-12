#!/bin/bash

# === Parameters ===
RESOURCE_GROUP="credit-rg-dev"
LOCATION="eastus"
ENVIRONMENT="dev"
TENANT_ID="<your-tenant-id>"         # Replace with your Azure AD tenant ID
OBJECT_ID="<your-object-id>"         # Replace with app registration or managed identity object ID

# === Create Resource Group ===
echo "Creating resource group: $RESOURCE_GROUP in $LOCATION..."
az group create --name "$RESOURCE_GROUP" --location "$LOCATION"

# === Deploy Bicep Template ===
echo "Deploying main.bicep..."
az deployment group create \
  --resource-group "$RESOURCE_GROUP" \
  --template-file ./main.bicep \
  --parameters location="$LOCATION" environment="$ENVIRONMENT" tenantId="$TENANT_ID" objectId="$OBJECT_ID"

echo "✅ Deployment complete."
