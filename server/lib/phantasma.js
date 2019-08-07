class PhantasmaAPI {

	const Opcodes = Object.freeze({
		NOP:   0,
		MOVE:   1,
		COPY:   2,
		PUSH:   3,
		POP:   4,
		SWAP:   5,
		CALL:   6,
		EXTCALL:   7,
		JMP:   8,
		JMPIF:   9,
		JMPNOT:   10,
		RET:   11,
		THROW:   12,
		LOAD:   13,
		CAST:   14,
		CAT:   15,
		SUBSTR:   16,
		LEFT:   17,
		RIGHT:   18,
		SIZE:   19,
		COUNT:   20,
		NOT:   21,
		AND:   22,
		OR:   23,
		XOR:   24,
		EQUAL:   25,
		LT:   26,
		GT:   27,
		LTE:   28,
		GTE:   29,
		INC:   30,
		DEC:   31,
		SIGN:   32,
		NEGATE:   33,
		ABS:   34,
		ADD:   35,
		SUB:   36,
		MUL:   37,
		DIV:   38,
		MOD:   39,
		SHL:   40,
		SHR:   41,
		MIN:   42,
		MAX:   43,
		THIS:   44,
		CTX:   45,
		SWITCH:   46,
		PUT:   47,
		GET:   48,
		
	});

	constructor(host) {
		this.host = host;
	}

	JSONRPC(method, params, onSuccess, onError) {
		let message = {
			'jsonrpc': '2.0',
			'method': method,
			'params': params,
			'id': '1'
		};
		let json = JSON.stringify(message);
		console.log(json);
		
		let request = new XMLHttpRequest();

		request.open('POST', this.host, true);

		request.onreadystatechange = function() {
			console.log(this.readyState);
			if (this.readyState === 4) { 
				if (this.status === 200) {
					let data = JSON.parse(request.responseText);
					if (data.result) {
						onSuccess(data.result);
					}
					else {
						onError('invalid response');				
					}
				}
				else {
					onError('connection error');				
				}
			} else {
				return true;
			}		  			
		};

		request.onerror = function() {
			onError('internal error');
		};

		request.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		request.setRequestHeader('Accept', 'application/json'); 
		request.send(json);
		console.log("sent");
	}

	convertDecimals(amount, decimals) {
		let mult = Math.pow(10, decimals);
		return amount / mult;
	}

	
	//Returns the account name and balance of given address.
	getAccount(addressText,onSuccess, onError)
	{
		let params = [addressText];
		this.JSONRPC('getAccount', params, onSuccess, onError);
	}

	//Returns the address that owns a given name.
	lookUpName(name,onSuccess, onError)
	{
		let params = [name];
		this.JSONRPC('lookUpName', params, onSuccess, onError);
	}

	//Returns the height of a chain.
	getBlockHeight(chainInput,onSuccess, onError)
	{
		let params = [chainInput];
		this.JSONRPC('getBlockHeight', params, onSuccess, onError);
	}

	//Returns the number of transactions of given block hash or error if given hash is invalid or is not found.
	getBlockTransactionCountByHash(blockHash,onSuccess, onError)
	{
		let params = [blockHash];
		this.JSONRPC('getBlockTransactionCountByHash', params, onSuccess, onError);
	}

	//Returns information about a block by hash.
	getBlockByHash(blockHash,onSuccess, onError)
	{
		let params = [blockHash];
		this.JSONRPC('getBlockByHash', params, onSuccess, onError);
	}

	//Returns a serialized string, containing information about a block by hash.
	getRawBlockByHash(blockHash,onSuccess, onError)
	{
		let params = [blockHash];
		this.JSONRPC('getRawBlockByHash', params, onSuccess, onError);
	}

	//Returns information about a block by height and chain.
	getBlockByHeight(chainInput,height,onSuccess, onError)
	{
		let params = [chainInput, height];
		this.JSONRPC('getBlockByHeight', params, onSuccess, onError);
	}

	//Returns a serialized string, in hex format, containing information about a block by height and chain.
	getRawBlockByHeight(chainInput,height,onSuccess, onError)
	{
		let params = [chainInput, height];
		this.JSONRPC('getRawBlockByHeight', params, onSuccess, onError);
	}

	//Returns the information about a transaction requested by a block hash and transaction index.
	getTransactionByBlockHashAndIndex(blockHash,index,onSuccess, onError)
	{
		let params = [blockHash, index];
		this.JSONRPC('getTransactionByBlockHashAndIndex', params, onSuccess, onError);
	}

	//Returns last X transactions of given address.
	getAddressTransactions(addressText,page,pageSize,onSuccess, onError)
	{
		let params = [addressText, page, pageSize];
		this.JSONRPC('getAddressTransactions', params, onSuccess, onError);
	}

	//Get number of transactions in a specific address and chain
	getAddressTransactionCount(addressText,chainInput,onSuccess, onError)
	{
		let params = [addressText, chainInput];
		this.JSONRPC('getAddressTransactionCount', params, onSuccess, onError);
	}

	//Allows to broadcast a signed operation on the network, but it&apos;s required to build it manually.
	sendRawTransaction(txData,onSuccess, onError)
	{
		let params = [txData];
		this.JSONRPC('sendRawTransaction', params, onSuccess, onError);
	}

	//Allows to invoke script based on network state, without state changes.
	invokeRawScript(chainInput,scriptData,onSuccess, onError)
	{
		let params = [chainInput, scriptData];
		this.JSONRPC('invokeRawScript', params, onSuccess, onError);
	}

	//Returns information about a transaction by hash.
	getTransaction(hashText,onSuccess, onError)
	{
		let params = [hashText];
		this.JSONRPC('getTransaction', params, onSuccess, onError);
	}

	//Removes a pending transaction from the mempool.
	cancelTransaction(hashText,onSuccess, onError)
	{
		let params = [hashText];
		this.JSONRPC('cancelTransaction', params, onSuccess, onError);
	}

	//Returns an array of all chains deployed in Phantasma.
	getChains(onSuccess, onError)
	{
		let params = [];
		this.JSONRPC('getChains', params, onSuccess, onError);
	}

	//Returns an array of tokens deployed in Phantasma.
	getTokens(onSuccess, onError)
	{
		let params = [];
		this.JSONRPC('getTokens', params, onSuccess, onError);
	}

	//Returns info about a specific token deployed in Phantasma.
	getToken(symbol,onSuccess, onError)
	{
		let params = [symbol];
		this.JSONRPC('getToken', params, onSuccess, onError);
	}

	//Returns data of a non-fungible token, in hexadecimal format.
	getTokenData(symbol,IDtext,onSuccess, onError)
	{
		let params = [symbol, IDtext];
		this.JSONRPC('getTokenData', params, onSuccess, onError);
	}

	//Returns an array of apps deployed in Phantasma.
	getApps(onSuccess, onError)
	{
		let params = [];
		this.JSONRPC('getApps', params, onSuccess, onError);
	}

	//Returns last X transactions of given token.
	getTokenTransfers(tokenSymbol,page,pageSize,onSuccess, onError)
	{
		let params = [tokenSymbol, page, pageSize];
		this.JSONRPC('getTokenTransfers', params, onSuccess, onError);
	}

	//Returns the number of transaction of a given token.
	getTokenTransferCount(tokenSymbol,onSuccess, onError)
	{
		let params = [tokenSymbol];
		this.JSONRPC('getTokenTransferCount', params, onSuccess, onError);
	}

	//Returns the balance for a specific token and chain, given an address.
	getTokenBalance(addressText,tokenSymbol,chainInput,onSuccess, onError)
	{
		let params = [addressText, tokenSymbol, chainInput];
		this.JSONRPC('getTokenBalance', params, onSuccess, onError);
	}

	//Returns the number of active auctions.
	getAuctionsCount(chainAddressOrName,symbol,onSuccess, onError)
	{
		let params = [chainAddressOrName, symbol];
		this.JSONRPC('getAuctionsCount', params, onSuccess, onError);
	}

	//Returns the auctions available in the market.
	getAuctions(chainAddressOrName,symbol,page,pageSize,onSuccess, onError)
	{
		let params = [chainAddressOrName, symbol, page, pageSize];
		this.JSONRPC('getAuctions', params, onSuccess, onError);
	}

	//Returns the auction for a specific token.
	getAuction(chainAddressOrName,symbol,IDtext,onSuccess, onError)
	{
		let params = [chainAddressOrName, symbol, IDtext];
		this.JSONRPC('getAuction', params, onSuccess, onError);
	}

	//Returns info about a specific archive.
	getArchive(hashText,onSuccess, onError)
	{
		let params = [hashText];
		this.JSONRPC('getArchive', params, onSuccess, onError);
	}
}