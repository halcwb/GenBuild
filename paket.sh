#!/usr/bin/env bash

set -eu
set -o pipefail

cd `dirname $0`

OS=${OS:-"unknown"}

function run() {
  if [[ "$OS" != "Windows_NT" ]]
  then
    mono "$@"
  else
    "$@"
  fi
}
#Only run the bootstrapper if no paket.exe
if [ ! -e .paket/paket.exe ]
	then
		run .paket/paket.bootstrapper.exe
fi

if [[ "$OS" != "Windows_NT" ]] &&
       [ ! -e ~/.config/.mono/certs ]
then
  mozroots --import --sync --quiet
fi

run .paket/paket.exe "$@"

