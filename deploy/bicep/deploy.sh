#!/bin/bash

# === Parameters ===


RESOURCE_GROUP="credit-rg-dev"
LOCATION="southindia"
ENVIRONMENT="dev"
IDENTITY_NAME="credit-mi-dev"

# === Create Resource Group ===
echo "Creating resource group: $RESOURCE_GROUP in $LOCATION..."
az group create -n $RESOURCE_GROUP --location $LOCATION

az identity create \
  --name $IDENTITY_NAME \
  --resource-group $RESOURCE_GROUP \
  --location $LOCATION

TENANT_ID=$(az account show --query tenantId --output tsv)
OBJECT_ID=$(az identity show -n $IDENTITY_NAME -g $RESOURCE_GROUP --query principalId -o tsv)

# === Deploy Bicep Template ===
echo "Deploying main.bicep..."
az deployment group create \
  --resource-group "$RESOURCE_GROUP" \
  --template-file ./main.bicep \
  --parameters location="$LOCATION" environment="$ENVIRONMENT" tenantId="$TENANT_ID" objectId="$OBJECT_ID"

echo "✅ Deployment complete."
