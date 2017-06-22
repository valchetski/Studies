class BaseError(Exception):
    def __init__(self, message=None):
        if message:
            self.message = message

    def __str__(self):
        return self.message

    def __repr__(self):
        return self.message


class StorageError(BaseError):
    pass


class ChannelError(BaseError):
    pass
